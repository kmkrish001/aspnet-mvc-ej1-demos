#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using MVCSampleBrowser.Models;
using System.Web;
using System.Web.Mvc;
using Syncfusion.JavaScript;

namespace MVCSampleBrowser.Controllers
{
    public partial class GanttController : Controller
    {
        //
        // GET: /GanttStriplines/

        public ActionResult GanttUnscheduledTasks()
        {
            var DataSource = GetUnscheduledData();
            ViewBag.datasource = DataSource;
            return View();
        }
        
        public List<GanttTaskDetails> GetUnscheduledData()
        {
            List<GanttTaskDetails> tasks = new List<GanttTaskDetails>();

            tasks.Add(new GanttTaskDetails()
            {
                TaskID = 1,
                TaskName = "Project Schedule",
                StartDate = "02/06/2017",                
                EndDate = "03/10/2017"
            });

            tasks[0].SubTasks = new List<GanttTaskDetails>();

            tasks[0].SubTasks.Add(new GanttTaskDetails()
            {
                TaskID = 2,
                TaskName = "Planning",
                StartDate = "02/06/2017",                
                EndDate = "02/10/2017"
            });

            tasks[0].SubTasks[0].SubTasks = new List<GanttTaskDetails>();


            tasks[0].SubTasks[0].SubTasks.Add(new GanttTaskDetails()
            {
                TaskID = 3,
                TaskName = "Plan timeline",
                StartDate = "02/01/2017",      
                Duration = null,
                Progress = "100",
                ResourceID = new List<object>() { 1 }
            });
            tasks[0].SubTasks[0].SubTasks.Add(new GanttTaskDetails()
            {
                TaskID = 4,
                TaskName = "Plan budget",                
                Duration = 5,
                Progress = "100",
                ResourceID = new List<object>() { 5 }
            });
            tasks[0].SubTasks[0].SubTasks.Add(new GanttTaskDetails()
            {
                TaskID = 5,
                TaskName = "Allocate resources",               
                EndDate = "02/7/2017",   
                Duration = null,
                Progress = "100",
                ResourceID = new List<object>() { 6 }
            });
            tasks[0].SubTasks[0].SubTasks.Add(new GanttTaskDetails()
            {
                TaskID = 6,
                TaskName = "Planning complete",
                StartDate = "02/06/2017",                
                Duration = 0,
                Predecessors = "3FS,5FS",
                ResourceID = new List<object>() { 1 }
            });

            tasks[0].SubTasks.Add(new GanttTaskDetails()
            {
                TaskID = 7,
                TaskName = "Design",
                StartDate = "02/10/2017",
                EndDate = "02/14/2017"
            });

            tasks[0].SubTasks[1].SubTasks = new List<GanttTaskDetails>();

            tasks[0].SubTasks[1].SubTasks.Add(new GanttTaskDetails()
            {
                TaskID = 8,
                TaskName = "Software Specification",               
                Duration = 3,
                Progress = "60",                
                ResourceID = new List<object>() { 2 }
            });
            tasks[0].SubTasks[1].SubTasks.Add(new GanttTaskDetails()
            {
                TaskID = 9,
                TaskName = "Develop prototype",
                StartDate = "02/03/2017",
                EndDate = "02/08/2017",                
                Progress = "100",
                Predecessors = "8FS",
                ResourceID = new List<object>() { 3 }
            });
            tasks[0].SubTasks[1].SubTasks.Add(new GanttTaskDetails()
            {
                TaskID = 10,
                TaskName = "Get approval from customer",
                StartDate = "02/07/2017",
                EndDate = "02/09/2017",
                Duration = 2,
                Progress = "100",
                Predecessors = "9FS",
                ResourceID = new List<object>() { 1 }
            });
            tasks[0].SubTasks[1].SubTasks.Add(new GanttTaskDetails()
            {
                TaskID = 11,
                TaskName = "Design complete",
                StartDate = "02/03/2017",
                EndDate = "02/09/2017",
                Duration = 0,
                Predecessors = "10FS",
                ResourceID = new List<object>() { 2 }
            });

            return tasks;

        }
        public class GanttTaskDetails
        {
            public int TaskID { get; set; }
            public string TaskName { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public int? Duration { get; set; }
            public string Progress { get; set; }
            public List<GanttTaskDetails> SubTasks { get; set; }
            public List<object> ResourceID { get; set; }
            public string Predecessors { get; set; }
        }
    }
}
