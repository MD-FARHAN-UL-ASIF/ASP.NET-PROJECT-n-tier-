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

    public class WorkstationController : ApiController
    {
        [HttpPost]
        [Route("api/work/create")]
        public HttpResponseMessage Create(WorkstationDTO workstation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = WorkstationService.Create(workstation);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Workstation created successfully.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Workstation creation failed!");
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
        [Route("api/work")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = WorkstationService.Get();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Workstation not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpGet]
        [Route("api/work/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = WorkstationService.Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Workstation not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/work/update/{id}")]
        public HttpResponseMessage Update(int id, WorkstationDTO workstation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Set the ID of the order to be updated
                    workstation.WorkstationID = id;

                    var isSuccess = WorkstationService.Update(workstation);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Workstation updated successfully.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Workstation not found!");
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
        [Route("api/work/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = WorkstationService.Delete(id);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Workstation deleted successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Workstation not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
