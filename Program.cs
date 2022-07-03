using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kysect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommandParser input = new CommandParser();
            input.Commands(args);
        }
    }
}
