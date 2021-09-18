using System;
using AppKit;

namespace Dever
{
    static class MainClass
    {
        static void Main(string[] args)
        {
                Database.CreateTable();
                NSApplication.Init();
                NSApplication.Main(args);
        }
    }
}
