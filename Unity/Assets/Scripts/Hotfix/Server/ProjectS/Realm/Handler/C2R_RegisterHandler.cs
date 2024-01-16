using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ET.Server;

/// <summary>
/// 客户端与Realm网关服务器通讯的注册账号消息处理
/// </summary>
[MessageSessionHandler(SceneType.Realm)]
[FriendOfAttribute(typeof (ET.Server.AccountInfo))]
public class C2R_RegisterHandler: MessageSessionHandler<C2R_Register, R2C_Register>
{
    protected override async ETTask Run(Session session, C2R_Register request, R2C_Register response)
    {
        session.RemoveComponent<SessionAcceptTimeoutComponent>(); //移除连接5秒超时组件（代表连接通过了验证，如果没有通过验证该组件5秒后会断开连接）

        int modCount = request.Account.Mode(StartSceneConfigCategory.Instance.Realms.Count); //对账号哈希值取模

        if (session.Root().Id != StartSceneConfigCategory.Instance.Realms[modCount].Id) //该账号是否登录到正确的Realm服务器
        {
            response.Error = ErrorCode.ERR_RealmAdressError; //Realm服务器地址错误
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        AccountInfosComponent accountInfosComponent = session.GetComponent<AccountInfosComponent>(); //获取该会话组件下的账号信息组件
        if (accountInfosComponent != null) //如果该会话下有账号信息组件则玩家重复登录
        {
            response.Error = ErrorCode.ERR_Register_Repeated; //重复注册相同账号
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        if (session.GetComponent<SessionLockingComponent>() != null) //如果会话组件锁不为空的情况下，说明服务器接收到客户端多次请求
        {
            response.Error = ErrorCode.ERR_Register_Repeated; //返回频繁请求多次错误码
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password1) || string.IsNullOrEmpty(request.Password2)) //判断账号密码是否为空
        {
            response.Error = ErrorCode.ERR_Register_InfoNull; //返回注册信息错误码
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        if (!Regex.IsMatch(request.Account.Trim(), @"^(?=.*[0-9].*)(?=.*[A-Za-z].*).{6,15}$")) //通过正则表达式，判断账号是否属于数字加大小写字母组合而成，如果不是
        {
            response.Error = ErrorCode.ERR_Register_AccountNameFormError; //返回注册账号格式错误码
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        if (!Regex.IsMatch(request.Password1.Trim(), @"^[A-Za-z0-9]+$") || !Regex.IsMatch(request.Password1.Trim(), @"^[A-Za-z0-9]+$")) //通过正则表达式，判断密码是否属于数字加大小写字母组合而成，如果不是
        {
            response.Error = ErrorCode.ERR_Register_PasswordFormError; //返回注册密码格式错误码
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }
        
        if (request.Password1 != request.Password2) //判断两次输入的密码是否正确
        {
            response.Error = ErrorCode.ERR_Register_PasswordError; //两次输入的密码不相同
            session.Disconnect().Coroutine(); //延迟1秒后断开连接
            return;
        }

        using (session.AddComponent<SessionLockingComponent>()) //会话组件锁（因为下面用到了异步逻辑，同一个用户的会话组件重复访问时会抢这把锁）
        {
            //异步逻辑块
            using (await session.Root().GetComponent<CoroutineLockComponent>()
                           .Wait(CoroutineLockType.RegisterAccount,
                               request.Account.GetLongHashCode())) //协程锁，所有用户都会抢这把锁，传入唯一id，用户账号名的哈希值（防止不同地址的用户用相同的账号去登录）
            {
                List<AccountInfo> accountInfos =
                        await session.GetDirectDB().Query<AccountInfo>(accountInfo => accountInfo.Account == request.Account); //在数据库里查询账号信息

                AccountInfo accountInfo = null;

                if (accountInfos.Count <= 0) //如果没有查询到账号信息
                {
                    accountInfosComponent = session.AddComponent<AccountInfosComponent>(); //添加账号信息组件
                    accountInfo = accountInfosComponent.AddChild<AccountInfo>(); //将该账号信息添加入账号信息组件下
                    
                    accountInfo.Account = request.Account.Trim(); //删除头部和尾部的空字符
                    accountInfo.Password = request.Password1.Trim();
                    accountInfo.CreateTime = TimeInfo.Instance.ServerNow(); //账号创建时间
                    accountInfo.AccountTye = (int)AccountTye.General; //普通类型账号

                    await session.GetDirectDB().Save(accountInfo); //将账号信息存入数据库

                }
                else
                {
                    response.Error = ErrorCode.ERR_Register_AccountExist; //该账号已被注册
                    session.Disconnect().Coroutine(); //延迟1秒后断开连接
                    return;
                }
            }
        }
    }
}