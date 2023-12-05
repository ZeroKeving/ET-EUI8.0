using CommandLine;
using System;
using System.Collections.Generic;

namespace ET
{
    public enum AppType
    {
        Server,
        Watcher, // 每台物理机一个守护进程，用来启动该物理机上的所有进程
        GameTool,
        ExcelExporter,
        Proto2CS,
        BenchmarkClient,
        BenchmarkServer,
        
        Demo,
        LockStep,
        ProjectS,
    }
    
    public class Options: Singleton<Options>
    {
        //App类型
        [Option("AppType", Required = false, Default = AppType.Server, HelpText = "AppType enum")]
        public AppType AppType { get; set; }

        //起服配置
        [Option("StartConfig", Required = false, Default = "StartConfig/Localhost")]
        public string StartConfig { get; set; }

        //进程id
        [Option("Process", Required = false, Default = 1)]
        public int Process { get; set; }
        
        //是否处于开发状态
        [Option("Develop", Required = false, Default = 0, HelpText = "develop mode, 0正式 1开发 2压测")]
        public int Develop { get; set; }

        //日志等级
        [Option("LogLevel", Required = false, Default = 0)]
        public int LogLevel { get; set; }
        
        //是否使用输入输出流进行交互
        [Option("Console", Required = false, Default = 0)]
        public int Console { get; set; }
    }
}