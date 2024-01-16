using System.Net;

namespace ET.Server;

[Invoke((long)SceneType.Name)]
public class FiberInit_Name: AInvokeHandler<FiberInit, ETTask>
{
    public override async ETTask Handle(FiberInit fiberInit)
    {
        Scene root = fiberInit.Fiber.Root;
        root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
        root.AddComponent<CoroutineLockComponent>();
        root.AddComponent<ProcessInnerSender>();
        root.AddComponent<MessageSender>();

        root.AddComponent<TempComponent>();//添加一个临时组件
        root.AddComponent<DBManagerComponent>();//数据库组件
        
        await ETTask.CompletedTask;
    }
}