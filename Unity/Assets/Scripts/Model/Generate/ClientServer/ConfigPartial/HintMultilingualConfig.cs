using System.Collections.Generic;

namespace ET;

/// <summary>
/// Hint提示多语言配置管理分部类
/// </summary>
public partial class HintMultilingualConfigCategory
{
    public Dictionary<int, string> Title = new();//多语言提醒标题
    public Dictionary<int, string> Desc = new();//多语言提醒描述
    public Dictionary<int, int> Type = new(); // 多语言提醒类型（强 中 弱 弹窗）
    public Dictionary<int, int> Icon = new(); // 多语言提醒图标
    
    
    /// <summary>
    /// 切换为中文
    /// </summary>
    public void Set_CN()
    {
        Title.Clear();
        Desc.Clear();
        Type.Clear();
        Icon.Clear();
        foreach (HintMultilingualConfig hintMultilingualConfig in this.dict.Values)
        {
            Title.Add(hintMultilingualConfig.Id,hintMultilingualConfig.CNTitle);
            Desc.Add(hintMultilingualConfig.Id,hintMultilingualConfig.CNDesc);
            Type.Add(hintMultilingualConfig.Id,hintMultilingualConfig.Type);
            Icon.Add(hintMultilingualConfig.Id,hintMultilingualConfig.Icon);
        }
    }
    
    /// <summary>
    /// 切换为英文
    /// </summary>
    public void Set_EN()
    {
        Title.Clear();
        Desc.Clear();
        Type.Clear();
        Icon.Clear();
        foreach (HintMultilingualConfig hintMultilingualConfig in this.dict.Values)
        {
            Title.Add(hintMultilingualConfig.Id,hintMultilingualConfig.ENTitle);
            Desc.Add(hintMultilingualConfig.Id,hintMultilingualConfig.ENDesc);
            Type.Add(hintMultilingualConfig.Id,hintMultilingualConfig.Type);
            Icon.Add(hintMultilingualConfig.Id,hintMultilingualConfig.Icon);
        }
    }
}