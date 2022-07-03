using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kysect
{
    internal class Task : VaultOfTasks
    {

        private string deadline;
        private List<SubTask> substask;
        
        protected int lastIdSubtask;

        public int Id { get; private set; }
        public bool Ready { get; protected set; }
        public string Info { get; protected set; }
        public List<SubTask> Substask { get; private set; }

        public string Deadline { 
            get { return deadline; } 
            set 
            { 
               if (Regex.IsMatch(value, @"[0 - 9]{ 2}/[0 - 9]{ 2}/[0 - 9]{ 4}"))
                {
                    deadline = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            } 
        }
        List<SubTask> subTasks = new List<SubTask>();
        public Task(int id, string info = "", bool ready = false, string deadline = "No deadline")
        {
            this.deadline = deadline;
            this.Ready = ready;
            this.Info = info;
            this.Id = id;
            this.lastIdSubtask = 0;
            this.substask = new List<SubTask>();
        }
        public Task(int id, List<SubTask> subTasks, string info = "", bool ready = false, string deadline = "No deadline") : this(id,info, ready, deadline)
        {
            this.subTasks = subTasks;
            this.lastIdSubtask = this.subTasks.Count; 
        }
        public void doReady()
        {
            if (!Ready) this.Ready = true;
            else Console.WriteLine("Alredy Ready");
        }

        public void addSubTask(SubTask task)
        {
            subTasks.Add(task);

        }

        public void AllInfo()
        {
            Console.WriteLine($"info: {this.Info}");
            Console.WriteLine($"isReady: {this.Ready}");
            Console.WriteLine($"deadline: {this.Deadline}");
            Console.Write("SubTasks:");
            foreach(SubTask subTask in this.subTasks)
            {
                Console.WriteLine("\n");
                subTask.allInfo();
            }

        }
        
    }
}
