using System.Collections.Generic;

namespace ET;

/// <summary>
/// 起服配置分部类
/// </summary>
public partial class StartZoneConfigCategory
{
    public Dictionary<int, string> TextDict = new();//多语言文本字典
    
    /// <summary>
    /// 切换为中文
    /// </summary>
    public void Set_CN()
    {
        TextDict.Clear();
        foreach (StartZoneConfig startZoneConfig in this.dict.Values)
        {
            TextDict.Add(startZoneConfig.Id,startZoneConfig.Name_CN);
        }
    }
    
    /// <summary>
    /// 切换为英文
    /// </summary>
    public void Set_EN()
    {
        TextDict.Clear();
        foreach (StartZoneConfig startZoneConfig in this.dict.Values)
        {
            TextDict.Add(startZoneConfig.Id,startZoneConfig.Name_EN);
        }
    }
}