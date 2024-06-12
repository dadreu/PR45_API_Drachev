using API_Drachev.Context;
using API_Drachev.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = API_Drachev.Model.Task;
namespace API_Drachev.Controllers
{
    [Route("api/TasksController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TaskContoller : Controller
    {

        [Route("List")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Task>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
            {
                try
                {
                    IEnumerable<Task> Tasks = new TaskContext().Tasks;
                    return Json(Tasks);
                }
                catch (Exception exp)
                {
                    return StatusCode(500, exp.Message);
                }
            }

            [Route("Item")]
            [HttpGet]
            [ProducesResponseType(typeof(Task), 200)]
            [ProducesResponseType(500)]
            public ActionResult Item(int Id)
            {
                try
                {
                    Task Tasks = new TaskContext().Tasks.Where(x => x.Id == Id).First();
                    return Json(Tasks);
                }
                catch (Exception exp)
                {
                    return StatusCode(500, exp.Message);
                }
            }
        }
    }

