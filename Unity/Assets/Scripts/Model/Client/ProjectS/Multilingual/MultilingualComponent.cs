namespace ET.Client;

public enum MultilingualType
{
    CN = 1,//中文
    EN = 2,//英文
}


/// <summary>
/// 多语言组件
/// </summary>
[ComponentOf(typeof(Scene))]
public class MultilingualComponent : Entity, IAwake, IDestroy
{
    public MultilingualType CurrentMultilingualType;//当前语言类型
}