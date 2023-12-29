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
        public const int ERR_LoginInfoNull = 200003;//登录账号密码为空
        public const int ERR_LoginAccountNameFormError = 200004;//登录账号格式错误
        public const int ERR_LoginPasswordFormError = 200005;//登录密码格式错误
        public const int ERR_LoginBlackListError = 200006;//登录账号属于黑名单
        public const int ERR_LoginPasswordError = 200007;//登录密码错误
        
    }
}