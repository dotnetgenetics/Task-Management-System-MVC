using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystemUsingEFMVC.Models;

namespace TaskManagementSystemUsingEFMVC.Controllers
{
    public class TaskController : Controller
    {
        private TaskManagementSystemEntities te;
        private TaskRepository taskRep;
        private ProjectRepository projRep;
        
        public TaskController()
        {
            te = new TaskManagementSystemEntities();
            projRep = new ProjectRepository();
            taskRep = new TaskRepository();
        }

        // GET: Task
        public ActionResult Index()
        {
            var model = new TaskAndTaskViewModel();
            int id = 0;
            int projectID = 0;

            if (TempData["TaskID"] != null)
            {
                id = Convert.ToInt32(TempData["TaskID"]);
                model.Task = te.Tasks.FirstOrDefault(t => t.TaskID == id);
                projectID = Convert.ToInt32(model.Task.ProjectID);
            }

            var projects = projRep.GetAllProjects();
            model.TaskViewModelList = new List<TaskViewModel>();
            model.TaskViewModelList = taskRep.GetAllTasks();
            model.SelectList =  from p in projects
                                select new SelectListItem{
                                    Selected = (p.ProjectID == projectID),
                                    Text = p.ProjectName,
                                    Value = p.ProjectID.ToString()
                                };
            return View(model);
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (task != null && task.TaskID <= 0)
            {
                taskRep.InsertTask(task);
            }

            return RedirectToAction("Index");
        }

        // POST: Task/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Task task)
        {
            if (task != null && task.TaskID > 0)
            {
                taskRep.UpdateTask(task);
            }

            return RedirectToAction("Index");
        }

        // POST: Task/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Task task)
        {
            if (task != null && task.TaskID > 0)
            {
                taskRep.Delete(task.TaskID);
            }

            return RedirectToAction("Index");
        }

        // POST: Task/Refresh
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Refresh()
        {
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Select(int id)
        {
            TempData["TaskID"] = id;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                te.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}