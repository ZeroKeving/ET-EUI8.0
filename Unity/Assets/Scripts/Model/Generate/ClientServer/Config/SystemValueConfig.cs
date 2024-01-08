using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class SystemValueConfigCategory : Singleton<SystemValueConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, SystemValueConfig> dict = new();
		
        public void Merge(object o)
        {
            SystemValueConfigCategory s = o as SystemValueConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public SystemValueConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SystemValueConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SystemValueConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SystemValueConfig> GetAll()
        {
            return this.dict;
        }

        public SystemValueConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class SystemValueConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>字段名称</summary>
		public string Name { get; set; }
		/// <summary>字段值</summary>
		public int[] Value { get; set; }

	}
}
