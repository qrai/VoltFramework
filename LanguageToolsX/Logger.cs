using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoltFramework.LanguageToolsX
{
    public interface IError
    {
        string Text { get; }
    }

    public class MemoryError : IError
    {
        public string Text { get; }
        public MemoryError(string text)
        {
            text = "MemoryError: " + text;
        }
    }
    public class AnalysisError : IError
    {
        public string Text { get; }
        public AnalysisError(string text)
        {
            text = "AnalysisError: " + text;
        }
    }
    public class RuntimeError : IError
    {
        public string Text { get; }
        public RuntimeError(string text)
        {
            text = "Runtime-Describer-Error: " + text;
        }
    }

    public static class Logger
    {

        public static void WarnCatch(string warn)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(warn);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ErrorCatch(IError err)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(err.Text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
