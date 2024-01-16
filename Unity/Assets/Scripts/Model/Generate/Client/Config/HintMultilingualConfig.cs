using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class HintMultilingualConfigCategory : Singleton<HintMultilingualConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, HintMultilingualConfig> dict = new();
		
        public void Merge(object o)
        {
            HintMultilingualConfigCategory s = o as HintMultilingualConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public HintMultilingualConfig Get(int id)
        {
            this.dict.TryGetValue(id, out HintMultilingualConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (HintMultilingualConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, HintMultilingualConfig> GetAll()
        {
            return this.dict;
        }

        public HintMultilingualConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class HintMultilingualConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>图标</summary>
		public int Icon { get; set; }
		/// <summary>提醒类型</summary>
		public int Type { get; set; }
		/// <summary>中文标题</summary>
		public string CNTitle { get; set; }
		/// <summary>中文描述</summary>
		public string CNDesc { get; set; }
		/// <summary>英文标题</summary>
		public string ENTitle { get; set; }
		/// <summary>英文描述</summary>
		public string ENDesc { get; set; }

	}
}
