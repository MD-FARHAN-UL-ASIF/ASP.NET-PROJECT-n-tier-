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
    public class LeaveController : ApiController
    {
   
        [HttpPost]
        [Route("api/leave/create")]
        public HttpResponseMessage Create(LeaveDTO leave)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = LeaveService.Create(leave);
                    if (data != null)
                    {
                        if (data.RemainingLeave < 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "Insufficient leave balance.");
                        }
                        else if (data.RemainingLeave == 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "No remaining leave slots available.");
                        }
                        else if (data == null)
                        {
                            return Request.CreateResponse(HttpStatusCode.InternalServerError);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.Created, "Leave Application Sent.");
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError);
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





        [HttpGet]
        [Route("api/leave/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = LeaveService.Get();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }



        [HttpGet]
        [Route("api/leave/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = LeaveService.Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //Search by employee id
        [HttpGet]
        [Route("api/leave/employee/{employeeId}")]
        public HttpResponseMessage GetAttendancesByEmployeeId(int employeeId)
        {
            var leaves = LeaveService.GetAttendancesByEmployeeId(employeeId);
            if (leaves == null || leaves.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No leave records found for the specified employee.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, leaves);
        }
        [HttpDelete]
        [Route("api/leave/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = LeaveService.Delete(id);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Leave Application terminated.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/leave/update/{id}")]
        public HttpResponseMessage Update(int id, LeaveDTO leave)
        {
            if (leave is null)
            {
                throw new ArgumentNullException(nameof(leave));
            }

            try
            {
                
                    leave.Id = id;
                    var isSuccess = LeaveService.Update(leave);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Leave Accepted.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError);
                    }
                
               
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
