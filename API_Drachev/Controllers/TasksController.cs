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

        /// <summary>
        /// Получение списка задач
        /// </summary>
        /// <remarks>Данный метод получает список задач, находящийся в БД</remarks>
        /// <response code="200">Задача успешно получена</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        /// <returns></returns>    
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

            /// <summary>
            /// Получение задачи
            /// </summary>
            /// <remarks>Данный метод получает задачу, находящуюся в БД</remarks>
            /// <response code="200">Задача успешно получена</response>
            /// <response code="500">При выполнении запроса возникли ошибки</response>
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
            /// <summary>
            /// Метод добавления задачи
            /// </summary>
            /// <param name="task"></param>
            /// <returns></returns>
            [Route("Add")]
            [HttpPut]
            [ApiExplorerSettings(GroupName = "v3")]
            [ProducesResponseType(200)]
            [ProducesResponseType(500)]
            public ActionResult Add([FromForm]Task task)
            {
                try
                {
                    TaskContext tasksContext = new TaskContext();
                    tasksContext.Tasks.Add(task);
                    tasksContext.SaveChanges();
                    return StatusCode(200);
                }
                catch (Exception exp)
                {
                    return StatusCode(500, exp.Message);
                }
            }
        ///<summary>
        ///Метод изменения задачи
        /// </summary>
        /// <param name="=task">Данные о задаче</param>
        /// <returns>Статус выполнения запроса</returns>
        ///<remarks>Данный метод изменяет задачу в базе данных</remarks>
        [Route("Edit")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult Edit([FromForm] Task task)
        {
            try
            {
                TaskContext taskContext = new TaskContext();
                var eTask = taskContext.Tasks.SingleOrDefault(x => x.Id == task.Id);
                if (eTask != null)
                {
                    eTask.Name = task.Name;
                    eTask.Priority = task.Priority;
                    eTask.DateExecute = task.DateExecute;
                    eTask.Comment = task.Comment;
                    eTask.Done = task.Done;
                    taskContext.SaveChanges();
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(400);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }

    }

