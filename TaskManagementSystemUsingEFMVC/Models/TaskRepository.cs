using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystemUsingEFMVC.Models
{
    public class TaskRepository
    {
        TaskManagementSystemEntities te;
        public TaskRepository()
        {
            te = new TaskManagementSystemEntities();
        }

        public List<TaskViewModel> GetAllTasks()
        {
            return te.Database.SqlQuery<TaskViewModel>("SPTasksAndProject", "").ToList();
        }

        public void InsertTask(Task task)
        {
            if (task != null)
            {
                te.Tasks.Add(task);
                te.SaveChanges();
            }
        }

        public void UpdateTask(Task task)
        {
            if (task != null)
            {
                var item = te.Tasks.Find(task.TaskID);
                if (item != null)
                {
                    te.Entry(item).CurrentValues.SetValues(task);
                    te.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            var itemDelete = te.Tasks.FirstOrDefault(t => t.TaskID == id);
            te.Entry(itemDelete).State = System.Data.Entity.EntityState.Deleted;
            te.SaveChanges();
        }
    }
}