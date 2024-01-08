using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class UIMultilingualConfigCategory : Singleton<UIMultilingualConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, UIMultilingualConfig> dict = new();
		
        public void Merge(object o)
        {
            UIMultilingualConfigCategory s = o as UIMultilingualConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public UIMultilingualConfig Get(int id)
        {
            this.dict.TryGetValue(id, out UIMultilingualConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (UIMultilingualConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, UIMultilingualConfig> GetAll()
        {
            return this.dict;
        }

        public UIMultilingualConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class UIMultilingualConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>中文</summary>
		public string CN { get; set; }
		/// <summary>英文</summary>
		public string EN { get; set; }

	}
}
