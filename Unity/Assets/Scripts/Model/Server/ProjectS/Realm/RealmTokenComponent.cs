using System.Collections.Generic;

namespace ET.Server;

/// <summary>
/// Gate网关令牌组件
/// </summary>
[ComponentOf(typeof(Scene))]
public class RealmTokenComponent : Entity, IAwake
{
    public readonly Dictionary<string, string> TokenDicKey = new();//登录令牌
}