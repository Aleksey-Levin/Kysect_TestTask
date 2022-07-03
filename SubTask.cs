using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kysect
{
    internal class SubTask : Task
    {
        public SubTask(int id, string info = "", bool ready = false): base(id, info, ready) {}
        public void allInfo()
        {
            Console.WriteLine($"info: {this.Info}");
            Console.WriteLine($"isReady: {this.Ready}");
        }
    }
}
