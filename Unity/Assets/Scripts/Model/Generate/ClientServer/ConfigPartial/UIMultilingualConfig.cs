using System.Collections.Generic;

namespace ET;

/// <summary>
/// UI多语言配置管理分部类
/// </summary>
public partial class UIMultilingualConfigCategory
{
    public Dictionary<int, string> TextDict = new();//多语言文本字典
    
    /// <summary>
    /// 切换为中文
    /// </summary>
    public void Set_CN()
    {
        TextDict.Clear();
        foreach (UIMultilingualConfig uIMultilingualConfig in this.dict.Values)
        {
            TextDict.Add(uIMultilingualConfig.Id,uIMultilingualConfig.CN);
        }
    }
    
    /// <summary>
    /// 切换为英文
    /// </summary>
    public void Set_EN()
    {
        TextDict.Clear();
        foreach (UIMultilingualConfig uIMultilingualConfig in this.dict.Values)
        {
            TextDict.Add(uIMultilingualConfig.Id,uIMultilingualConfig.EN);
        }
    }
}