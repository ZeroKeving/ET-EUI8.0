using UnityEngine;

namespace ET.Client;

[EntitySystemOf(typeof (MultilingualComponent))]
[FriendOf(typeof (MultilingualComponent))]
public static partial class MultilingualComponentSystem
{
    [EntitySystem]
    private static void Awake(this MultilingualComponent self)
    {
        if (PlayerPrefs.GetInt("MultilingualType") != 0)//如果本地有多语言设置
        {
            self.CurrentMultilingualType = (MultilingualType)PlayerPrefs.GetInt("MultilingualType");
        }
        else//从未设置过
        {
            self.CurrentMultilingualType = (MultilingualType)SystemValueConfigCategory.Instance.SystemValueDict["DefaultMultilingual"][0];
        }

        self.MultilingualConfigLoad();//加载多语言配置
    }

    [EntitySystem]
    private static void Destroy(this MultilingualComponent self)
    {
    }

    /// <summary>
    /// 改变多语言类型
    /// </summary>
    public static void ChangeMultilingualType(this MultilingualComponent self,int multilingualType)
    {
        self.CurrentMultilingualType = (MultilingualType)multilingualType;//设置当前多语言类型
        self.MultilingualConfigLoad();//加载多语言配置
        //设置成功后，在本地保留多语言信息
        PlayerPrefs.SetInt("MultilingualType",multilingualType);
        self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgStartGameUI>().Refresh();//刷新开始界面
    }
    
    /// <summary>
    /// 加载多语言配置
    /// </summary>
    /// <param name="self"></param>
    public static void MultilingualConfigLoad(this MultilingualComponent self)
    {
        switch (self.CurrentMultilingualType)
        {
            case MultilingualType.CN://中文
                UIMultilingualConfigCategory.Instance.Set_CN();
                break;
            case MultilingualType.EN://英文
                UIMultilingualConfigCategory.Instance.Set_EN();
                break;
            default:
                return;
        }
    }
    
}