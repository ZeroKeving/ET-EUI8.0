using System;

namespace ET.Server
{
    /// <summary>
    /// 数据库管理组件系统
    /// </summary>
    [FriendOf(typeof(DBManagerComponent))]
    public static partial class DBManagerComponentSystem
    {
        public static DBComponent GetZoneDB(this DBManagerComponent self, int zone)
        {
            DBComponent dbComponent = self.DBComponents[zone];
            if (dbComponent != null)
            {
                return dbComponent;
            }

            StartZoneConfig startZoneConfig = StartZoneConfigCategory.Instance.Get(zone);
            if (startZoneConfig.DBConnection == "")
            {
                throw new Exception($"zone: {zone} not found mongo connect string");
            }

            dbComponent = self.AddChild<DBComponent, string, string, int>(startZoneConfig.DBConnection, startZoneConfig.DBName, zone);
            self.DBComponents[zone] = dbComponent;
            return dbComponent;
        }

        /// <summary>
        /// 直连数据库
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static DBComponent GetDirectDB(this Entity self)
        {
            return self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()); //传入区服信息id获取对应的数据库连接组件
        }
    }
}