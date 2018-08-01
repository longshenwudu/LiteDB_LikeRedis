using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LiteDB.Shell.Commands
{
    [Help(
        Category = "Database",
        Name = "close",
        Syntax = "close",
        Description = "Close current datafile"
    )]
    internal class Close : IShellCommand
    {
        public bool IsCommand(StringScanner s)
        {
            return s.Scan(@"close$").Length > 0;
        }

        public void Execute(StringScanner s, Env env, out bool b, out object obj)
        {
            b = false;
            obj = null;
            env.Close();
        }
    }
}