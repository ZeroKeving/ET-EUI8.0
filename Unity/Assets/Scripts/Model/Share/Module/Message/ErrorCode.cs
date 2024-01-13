namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误
        
        // 110000以下的错误请看ErrorCore.cs
        
        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常

        public const int ERR_NetWorkError = 200002;//网络异常
        public const int ERR_Login_InfoNull = 200003;//登录账号密码为空
        public const int ERR_Login_AccountNameFormError = 200004;//登录账号格式错误
        public const int ERR_Login_PasswordFormError = 200005;//登录密码格式错误
        public const int ERR_Login_BlackListError = 200006;//登录账号属于黑名单
        public const int ERR_Login_PasswordError = 200007;//登录密码错误
        public const int ERR_Login_RepeatedLogin = 200008;//重复登录相同账号
        public const int ERR_TokenError = 200009;//登录令牌错误
        public const int ERR_RealmAdressError = 200010;//Realm服务器地址错误
        public const int ERR_Login_AccountNotExist = 200011;//该账号未注册
        
        public const int ERR_Register_Repeated = 200012;//重复注册相同账号
        public const int ERR_Register_InfoNull = 200013;//注册账号密码为空
        public const int ERR_Register_AccountNameFormError = 200014;//注册账号格式错误
        public const int ERR_Register_PasswordFormError = 200015;//注册密码格式错误
        public const int ERR_Register_PasswordError = 200016;//两次输入的密码不相同
        public const int ERR_Register_AccountExist = 200017;//该账号已被注册
        
        public const int ERR_Zone_ZoneNotFound = 200018;//未找到区服信息
        public const int ERR_Zone_LoginTimeout = 200019;//找不到登录令牌（登录超时，请玩家重新登录）
        
        public const int ERR_Gate_NotLoginGateInfo = 200020;//未找到登录Gate信息
        
        //300000以上为提示码
        
        //400000以上为告知码，不做任何提示处理
        public const int Inform_NewSession = 400001;//新建连接
        
    }
}