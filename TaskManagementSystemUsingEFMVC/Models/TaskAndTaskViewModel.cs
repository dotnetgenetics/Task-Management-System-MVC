using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagementSystemUsingEFMVC.Models
{
    public class TaskAndTaskViewModel
    {
        public Task Task { get; set; }
        public List<TaskViewModel> TaskViewModelList { get; set; }
        public IEnumerable<SelectListItem> SelectList { get; set; }
    }
}