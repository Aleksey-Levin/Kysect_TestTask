using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kysect
{
    public class CommandParser
    {
        public void Commands(string?[] args)
        {
            VaultOfTasks vaultOfTasks = new VaultOfTasks();
            for (int i = 0; i < args.Length - 1; ++i)
            {
                if (args[i] is null)
                {
                    return;
                }
                switch (args[i])
                {
                    case "/add":

                        vaultOfTasks.AddTask(new Task(Convert.ToInt32(args[i + 4]), args[i + 5], Convert.ToBoolean(args[i + 6])));
                        break;
                    case "/all":
                        vaultOfTasks.allInfo();
                        break;
                    case "/delete":
                        vaultOfTasks.RemoveTask(Convert.ToInt32(args[i + 1]));
                        break;
                    case "/completed":
                        vaultOfTasks.ChangeTaskStatus(Convert.ToInt32(args[i + 1]));
                        break;
                    case "/create-group":
                        vaultOfTasks.AddGroup(new GroupTask(Convert.ToInt32(args[i + 1])));
                        break;
                    case "/delete-group":
                        vaultOfTasks.RemoveGroup(Convert.ToInt32(args[i + 1]));
                        break;
                    case "/add-to-group":
                        vaultOfTasks.addTaskOnGroup(Convert.ToInt32(args[i + 1]), Convert.ToInt32(args[i + 2]));
                        break;
                    case "/delete-from-group":
                        vaultOfTasks.removeTaskOnGroup(Convert.ToInt32(args[i + 1]), Convert.ToInt32(args[i + 2]));
                        break;
                    case "/add-subtask":
                        SubTask sub1 = new SubTask(Convert.ToInt32(args[i + 2]), args[i + 3], Convert.ToBoolean(args[i + 1]));
                        vaultOfTasks.addSubTask(Convert.ToInt32(args[i + 5]), sub1);
                        break;
                    case "/change-sub-status":
                        vaultOfTasks.changeSubStatus(Convert.ToInt32(args[i + 1]), Convert.ToInt32(args[i + 1]));
                        break;
                    case "/today":
                        vaultOfTasks.GetTodayTasks();
                        break;
                }
            }
        }
    }
}
