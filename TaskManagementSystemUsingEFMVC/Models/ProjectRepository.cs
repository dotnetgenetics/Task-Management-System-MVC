using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystemUsingEFMVC.Models
{
    public class ProjectRepository
    {
        TaskManagementSystemEntities te;

        public ProjectRepository()
        {
            te = new TaskManagementSystemEntities();
        }

        public List<Project> GetAllProjects()
        {
            return te.Projects.ToList();
        }
    }
}