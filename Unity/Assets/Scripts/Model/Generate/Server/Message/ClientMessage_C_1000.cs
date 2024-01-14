using ET;
using MemoryPack;
using System.Collections.Generic;
namespace ET
{
// using
	[ResponseType(nameof(NetClient2Main_Login))]
	[Message(ClientMessage.Main2NetClient_Login)]
	[MemoryPackable]
	public partial class Main2NetClient_Login: MessageObject, IRequest
	{
		public static Main2NetClient_Login Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Main2NetClient_Login), isFromPool) as Main2NetClient_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int OwnerFiberId { get; set; }

		[MemoryPackOrder(2)]
		public string Account { get; set; }

		[MemoryPackOrder(3)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OwnerFiberId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(ClientMessage.NetClient2Main_Login)]
	[MemoryPackable]
	public partial class NetClient2Main_Login: MessageObject, IResponse
	{
		public static NetClient2Main_Login Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(NetClient2Main_Login), isFromPool) as NetClient2Main_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long PlayerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(NetClient2Main_LoginGame))]
	[Message(ClientMessage.Main2NetClient_LoginGame)]
	[MemoryPackable]
	public partial class Main2NetClient_LoginGame: MessageObject, IRequest
	{
		public static Main2NetClient_LoginGame Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Main2NetClient_LoginGame), isFromPool) as Main2NetClient_LoginGame; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int OwnerFiberId { get; set; }

		[MemoryPackOrder(2)]
		public string Account { get; set; }

		[MemoryPackOrder(3)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OwnerFiberId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(ClientMessage.NetClient2Main_LoginGame)]
	[MemoryPackable]
	public partial class NetClient2Main_LoginGame: MessageObject, IResponse
	{
		public static NetClient2Main_LoginGame Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(NetClient2Main_LoginGame), isFromPool) as NetClient2Main_LoginGame; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public List<ServerListInfoProto> ServerListInfosProto { get; set; } = new();

		[MemoryPackOrder(4)]
		public string Token { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.ServerListInfosProto.Clear();
			this.Token = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(NetClient2Main_Register))]
	[Message(ClientMessage.Main2NetClient_Register)]
	[MemoryPackable]
	public partial class Main2NetClient_Register: MessageObject, IRequest
	{
		public static Main2NetClient_Register Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Main2NetClient_Register), isFromPool) as Main2NetClient_Register; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int OwnerFiberId { get; set; }

		[MemoryPackOrder(2)]
		public string Account { get; set; }

		[MemoryPackOrder(3)]
		public string Password1 { get; set; }

		[MemoryPackOrder(4)]
		public string Password2 { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OwnerFiberId = default;
			this.Account = default;
			this.Password1 = default;
			this.Password2 = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(ClientMessage.NetClient2Main_Register)]
	[MemoryPackable]
	public partial class NetClient2Main_Register: MessageObject, IResponse
	{
		public static NetClient2Main_Register Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(NetClient2Main_Register), isFromPool) as NetClient2Main_Register; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(NetClient2Main_EnterGame))]
	[Message(ClientMessage.Main2NetClient_EnterGame)]
	[MemoryPackable]
	public partial class Main2NetClient_EnterGame: MessageObject, IRequest
	{
		public static Main2NetClient_EnterGame Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Main2NetClient_EnterGame), isFromPool) as Main2NetClient_EnterGame; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int OwnerFiberId { get; set; }

		[MemoryPackOrder(2)]
		public string Account { get; set; }

		[MemoryPackOrder(3)]
		public string Password { get; set; }

		[MemoryPackOrder(4)]
		public int Zone { get; set; }

		[MemoryPackOrder(5)]
		public string Token { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OwnerFiberId = default;
			this.Account = default;
			this.Password = default;
			this.Zone = default;
			this.Token = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(ClientMessage.NetClient2Main_EnterGame)]
	[MemoryPackable]
	public partial class NetClient2Main_EnterGame: MessageObject, IResponse
	{
		public static NetClient2Main_EnterGame Create(bool isFromPool = false) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(NetClient2Main_EnterGame), isFromPool) as NetClient2Main_EnterGame; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long PlayerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	public static class ClientMessage
	{
		 public const ushort Main2NetClient_Login = 1001;
		 public const ushort NetClient2Main_Login = 1002;
		 public const ushort Main2NetClient_LoginGame = 1003;
		 public const ushort NetClient2Main_LoginGame = 1004;
		 public const ushort Main2NetClient_Register = 1005;
		 public const ushort NetClient2Main_Register = 1006;
		 public const ushort Main2NetClient_EnterGame = 1007;
		 public const ushort NetClient2Main_EnterGame = 1008;
	}
}
