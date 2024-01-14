namespace ET
{
    /// <summary>
    /// 常量
    /// </summary>
    public static partial class ConstValue
    {
        //开服配置：RouterMananger服务器的地址和端口
        public const string RouterHttpHost = "127.0.0.1";
        public const int RouterHttpPort = 30300;//RouterManager的端口
        public const int SessionTimeoutTime = 30 * 1000;
        
        public const int Login_GateUserDisconnectTime = 20 * 1000;//防止一直不进行后续登录的下线时间(顶号者的保留时间)
        public const int Login_SessionDisconnectTime = 60 * 1000;//断线保留时间
    }
}