using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ET.Server;

/// <summary>
/// 客户端与Realm网关服务器通讯的登录游戏消息处理
/// </summary>
[MessageSessionHandler(SceneType.Realm)]
[FriendOfAttribute(typeof (ET.Server.AccountInfo))]
public class C2R_LoginGameHandler: MessageSessionHandler<C2R_LoginGame, R2C_LoginGame>
{
    protected override async ETTask Run(Session session, C2R_LoginGame request, R2C_LoginGame response)
    {
        session.RemoveComponent<SessionAcceptTimeoutComponent>(); //移除连接5秒超时组件（代表连接通过了验证，如果没有通过验证该组件5秒后会断开连接）

        int modCount = Math.Abs(request.Account.GetHashCode() % StartSceneConfigCategory.Instance.Realms.Count); //对账号哈希值取模的绝对值

        if (session.Root().Id != StartSceneConfigCategory.Instance.Realms[modCount].Id) //该账号是否登录到正确的Realm服务器
        {
            response.Error = ErrorCode.ERR_RealmAdressError; //Realm服务器地址错误
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        AccountInfosComponent accountInfosComponent = session.GetComponent<AccountInfosComponent>(); //获取该会话组件下的账号信息组件
        if (accountInfosComponent != null) //如果该会话下有账号信息组件则玩家重复登录
        {
            response.Error = ErrorCode.ERR_Login_RepeatedLogin; //重复登录
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        if (session.GetComponent<SessionLockingComponent>() != null) //如果会话组件锁不为空的情况下，说明服务器接收到客户端多次请求
        {
            response.Error = ErrorCode.ERR_Login_RepeatedLogin; //返回频繁请求多次错误码
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password)) //判断账号密码是否为空
        {
            response.Error = ErrorCode.ERR_Login_InfoNull; //返回登录信息错误码
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        if (!Regex.IsMatch(request.Account.Trim(), @"^(?=.*[0-9].*)(?=.*[A-Za-z].*).{6,15}$")) //通过正则表达式，判断账号是否属于数字加大小写字母组合而成，如果不是
        {
            response.Error = ErrorCode.ERR_Login_AccountNameFormError; //返回登录账号格式错误码
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        if (!Regex.IsMatch(request.Password.Trim(), @"^[A-Za-z0-9]+$")) //通过正则表达式，判断密码是否属于数字加大小写字母组合而成，如果不是
        {
            response.Error = ErrorCode.ERR_Login_PasswordFormError; //返回登录密码格式错误码
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        
        
        using (session.AddComponent<SessionLockingComponent>()) //会话组件锁（因为下面用到了异步逻辑，同一个用户的会话组件重复访问时会抢这把锁）
        {
            //异步逻辑块
            using (await session.Root().GetComponent<CoroutineLockComponent>()
                           .Wait(CoroutineLockType.LoginAccount,
                               request.Account.GetLongHashCode())) //协程锁，所有用户都会抢这把锁，传入唯一id，用户账号名的哈希值（防止不同地址的用户用相同的账号去登录）
            {
                List<AccountInfo> accountInfos =
                        await session.GetDirectDB().Query<AccountInfo>(accountInfo => accountInfo.Account == request.Account); //在数据库里查询账号信息

                AccountInfo accountInfo = null;

                if (accountInfos.Count <= 0) //如果没有查询到账号信息
                {
                    response.Error = ErrorCode.ERR_Login_AccountNotExist; //该账号未注册
                    session.Disconnect().Coroutine(); //延迟1秒后断开连接
                    return;
                }
                else
                {
                    accountInfo = accountInfos[0]; //取出第一个账号密码

                    if (accountInfo.AccountTye == (int)AccountTye.BlackList) //如果账号在黑名单中
                    {
                        response.Error = ErrorCode.ERR_Login_BlackListError; //返回登录账号属于黑名单错误码
                        session.Disconnect().Coroutine(); //延迟1秒后断开连接
                        return;
                    }

                    if (accountInfo.Password != request.Password) //如果密码错误
                    {
                        response.Error = ErrorCode.ERR_Login_PasswordError; //登录密码错误
                        session.Disconnect().Coroutine(); //延迟1秒后断开连接
                        return;
                    }
                    
                    accountInfosComponent = session.AddComponent<AccountInfosComponent>(); //添加账号信息组件
                    accountInfo = accountInfosComponent.AddChild<AccountInfo>(); //将该账号信息添加入账号信息组件下
                }

                // //可以根据当前模式做对应操作
                // if (Options.Instance.Develop == 0) //当前模式：0正式 1开发 2压测
                // {
                //     //正式上线部署模式
                // }
                // else
                // {
                //     //开发模式
                // }

            }
        }

        //返回游戏区服列表
        foreach (StartZoneConfig startZoneConfig in StartZoneConfigCategory.Instance.GetAll().Values)
        {
            if (startZoneConfig.ZoneTpye != (int)ZoneType.Game)//如果不为游戏区服直接略过
            {
                continue;
            }
            
            response.ServerListInfosProto.Add(new ServerListInfoProto(){ Zone = startZoneConfig.Id,Name = startZoneConfig.Name,Status = RandomGenerator.RandomNumber(0,2)});
        }
                
        string Token = TimeInfo.Instance.ServerNow().ToString() + RandomGenerator.RandInt64();//随机生成一个令牌
        session.Root().GetComponent<RealmTokenComponent>().Add(request.Account, Token);//在Gate网关钥匙组件上添加该账号,等待20秒后移除该账号的登录钥匙
        response.Token = Token;
        
        session.Disconnect().Coroutine(); //延迟1秒后断开连接
    }
}