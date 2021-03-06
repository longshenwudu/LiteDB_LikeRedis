using System;
using System.IO;

namespace LiteDB.Shell.Commands
{
    [Help(
        Category = "Shell",
        Name = "run",
        Syntax = "run <filename>",
        Description = "Queue shell commands inside filename to be run in order.",
        Examples = new string[] {
            "run scripts.txt"
        }
    )]
    internal class Run : IShellCommand
    {
        public bool IsCommand(StringScanner s)
        {
            return s.Scan(@"run\s+").Length > 0;
        }

        public void Execute(StringScanner s, Env env, out bool b, out object obj)
        {
            b = false;
            obj = null;
            if (env.Engine == null) throw ShellException.NoDatabase();

            var filename = s.Scan(@".+").Trim();

            foreach (var line in File.ReadAllLines(filename))
            {
                env.Input.Queue.Enqueue(line);
            }
        }
    }
}