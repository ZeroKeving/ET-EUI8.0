using System.Collections.Generic;

namespace ET;

/// <summary>
/// 系统值配置管理分部类
/// </summary>
public partial class SystemValueConfigCategory
{
    public Dictionary<string, int[]> SystemValueDict = new();//系统值字典
    
    /// <summary>
    /// 重写初始化
    /// </summary>
    public override void EndInit()
    {
        base.EndInit();
        
        foreach (SystemValueConfig systemValueConfig in this.dict.Values)
        {
            SystemValueDict.Add(systemValueConfig.Name,systemValueConfig.Value);
        }
    }
}