using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystemUsingEFMVC.Models
{
    public class TaskViewModel
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskDuration { get; set; }
        public string ProjectName { get; set; }
        public int ProjectID { get; set; }
    }
}