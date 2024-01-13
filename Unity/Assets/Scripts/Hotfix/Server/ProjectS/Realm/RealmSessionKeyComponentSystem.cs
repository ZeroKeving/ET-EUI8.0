namespace ET.Server;

/// <summary>
/// Realm网关令牌组件
/// </summary>
[FriendOf(typeof(RealmTokenComponent))]
public static partial class RealmTokenComponentSystem
{
    public static void Add(this RealmTokenComponent self, string key, string token)
    {
        self.TokenDicKey.Add(key, token);
        self.TimeoutRemoveKey(key,token).Coroutine();//3分钟后移除该账号的登录钥匙
    }

    public static string Get(this RealmTokenComponent self, string key)
    {
        string value = null;
        self.TokenDicKey.TryGetValue(key, out value);
        return value;
    }

    public static void Remove(this RealmTokenComponent self, string key)
    {
        if (self.TokenDicKey.ContainsKey(key))
        {
            self.TokenDicKey.Remove(key);
        }
    }

    /// <summary>
    /// 令牌过期后移除
    /// </summary>
    /// <param name="self"></param>
    /// <param name="key"></param>
    private static async ETTask TimeoutRemoveKey(this RealmTokenComponent self, string key,string token)
    {
        await self.Root().GetComponent<TimerComponent>().WaitAsync(180000);//等待3分钟后

        string onlineToken = self.Get(key);

        if (!string.IsNullOrEmpty(token) && onlineToken == token)//如果令牌不为空且传入进来的令牌保持一致
        {
            self.Remove(key);//从令牌字典中移除指定令牌
        }
    }
}