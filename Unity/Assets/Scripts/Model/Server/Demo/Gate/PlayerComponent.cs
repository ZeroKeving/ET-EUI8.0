using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
	/// <summary>
	/// 玩家组件
	/// </summary>
	[ComponentOf(typeof(Scene))]
	public class PlayerComponent : Entity, IAwake, IDestroy
	{
		public Dictionary<string, Player> dictionary = new Dictionary<string, Player>();
	}
}