using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kysect
{
    internal class GroupTask
    {
        public int Id { get; private set; }
        private List<Task> tasks = new List<Task>() { };

        public List<Task> TaskS { get { return tasks; }}
        public string Name { get; protected set; }
        public GroupTask(int id = 1, string name = "")
        {
            this.Id = id;
            this.Name = name;
        }

        public void AddTaskOnGroup(Task task) {
            tasks.Add(task);
        }

        public void RemoveTaskOnGroup(Task task) {
            tasks.Remove(task);
        }

        
    }
}
