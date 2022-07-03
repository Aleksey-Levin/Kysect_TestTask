using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kysect
{
    internal class VaultOfTasks
    {
        private List<Task> tasks;
        private List<GroupTask> groupTask;

        protected int id;
        public List<Task> Tasks { get; private set; }
        public List<GroupTask> GroupTask { get; private set; }

        public VaultOfTasks()
        { 
            this.tasks = new List<Task>();
        }
        public VaultOfTasks(List<Task> tasks) : this()
        {
            this.tasks = tasks;
        }
        public VaultOfTasks(List<GroupTask> groupTasks) : this()
        {
            this.groupTask = groupTasks;
        }
        public VaultOfTasks(List<Task> tasks, List<GroupTask> groupTasks): this()
        {
            this.tasks = tasks;
            this.groupTask = groupTasks;
        }

        public void AddTask(Task task)
        {
            this.tasks.Add(task);
        }

        public void AddGroup(GroupTask group)
        {
            this.groupTask.Add(group);
        }

        public GroupTask findGroup(int id)
        {
            foreach (var group in groupTask)
            {
                if (group.Id == id)
                {
                    return group;
                }
            }
            throw new Exception("Can't find group");
        }
        public Task findTask(int id)
        {
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    return task;
                }
            }
            throw new Exception("Can't find task");
        }

        public SubTask findSubTask(int id, Task task)
        {
            foreach (var subtask in task.Substask)
            {
                if (subtask.Id == id)
                {
                    return subtask;
                }
            }
            throw new Exception("Can't find subtask");
        }

        public void RemoveTask(int id)
        {
            tasks.Remove(findTask(id));
        }

        public void RemoveGroup(int id)
        {
            groupTask.Remove(findGroup(id));
        }

        public List<Task> GetTodayTasks()
        {
            List<Task> totalTask = new List<Task>();
            DateTime thisDay = DateTime.Today;
            for (int i = 0; i < this.tasks.Count; i++)
            {
                if(tasks[i].Deadline == thisDay.ToString())
                {
                    totalTask.Add(tasks[i]);
                }
            }
            return totalTask;
        }

        public void allInfo()
        {
            foreach(Task task in this.tasks)
            {
                task.allInfo();
            }
        }

        public void ChangeTaskStatus(int id)
        {
            findTask(id).doReady();
        }

        public void addTaskOnGroup(int idTask, int idGroup)
        {
            findGroup(idGroup).AddTaskOnGroup(findTask(idTask));

        }

        public void removeTaskOnGroup(int idTask, int idGroup)
        {
            findGroup(idGroup).RemoveTaskOnGroup(findTask(idTask));

        }

        public void addSubTask(int id, SubTask subTask)
        {
            findTask(id).addSubTask(subTask);

        }
        public void changeSubStatus(int idTask, int idSubTask)
        {
            findSubTask(idSubTask, findTask(idTask)).doReady();
        }
    }
}
