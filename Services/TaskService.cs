using lesson_1.Models;
using System.Collections.Generic;
using System.Linq;

namespace lesson_1.Controllers
{
    public static class TaskService
    {
        private static List<MyTask> tasks = new List<MyTask>
        {
            new MyTask(){Id=1, Description="task1", IsDone=false},
            new MyTask(){Id=2, Description="task2", IsDone=true}
        };

        public static List<MyTask> GetAll()
        {
            return tasks;
        }

        public static MyTask Get(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }

        public static void Add(MyTask task)
        {
              task.Id=tasks.Max(t=> t.Id)+1;
              tasks.Add(task);
        }

        public static bool Update(int id, MyTask newTask)
        {
            if(newTask.Id!=id)
                return false;
                 var t=tasks.FirstOrDefault(task=> task.Id==id);
            if(t==null)
                return false;
            t.Id=newTask.Id;
            t.Description=newTask.Description;
            t.IsDone=newTask.IsDone;
            return true;
        }

        public static bool Delete(int id)
        { 
            var t=tasks.FirstOrDefault(t => t.Id == id);
            if(t==null)
                return false;
            tasks.Remove(t);
            return true;
        }
    }
}