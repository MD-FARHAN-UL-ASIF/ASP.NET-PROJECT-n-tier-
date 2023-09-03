using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OUTLOOK_GMS.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TaskController : ApiController
    {
        [HttpPost]
        [Route("api/task/create")]
        public HttpResponseMessage Create(TaskDTO task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = TaskService.Create(task);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Task created successfully.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Task creation failed!");
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model state is invalid");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/task")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = TaskService.Get();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Task not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpGet]
        [Route("api/task/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = TaskService.Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Task not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/task/update/{id}")]
        public HttpResponseMessage Update(int id, TaskDTO task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Set the ID of the order to be updated
                    task.TaskID = id;

                    var isSuccess = TaskService.Update(task);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Task updated successfully.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Task not found!");
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("api/task/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = TaskService.Delete(id);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Task deleted successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Task not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
