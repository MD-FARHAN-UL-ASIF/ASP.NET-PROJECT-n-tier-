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
    public class AttendanceController : ApiController
    {
        
        [HttpPost]
        [Route("api/attendance/create")]
        public HttpResponseMessage Create(AttendanceDTO attendance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = AttendanceService.Create(attendance);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Attendance created successfully.");
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
        [Route("api/attendance/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AttendanceService.Get();
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
        [Route("api/attendance/{attendanceId}")]
        public HttpResponseMessage Get(int attendanceId)
        {
            try
            {
                var data = AttendanceService.Get(attendanceId);
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
        [Route("api/attendance/employee/{employeeId}")]
        public HttpResponseMessage GetAttendancesByEmployeeId(int employeeId)
        {
            var attendances = AttendanceService.GetAttendancesByEmployeeId(employeeId);
            if (attendances == null || attendances.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No attendance records found for the specified employee.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, attendances);
        }

        //search by date
        [HttpGet]
        [Route("api/attendance/bydate/{date}")]
        public HttpResponseMessage GetByDate(DateTime date)
        {
            try
            {
                var attendances = AttendanceService.GetAttendancesByDate(date);
                if (attendances != null && attendances.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, attendances);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No attendance records found for the specified date.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPut]
        [Route("api/attendance/update/{attendanceId}")]
        public HttpResponseMessage Update(int attendanceId, AttendanceDTO attendance)
        {
            if (attendance is null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Attendance data is missing.");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    attendance.AttendanceId = attendanceId;
                    var isSuccess = AttendanceService.Update(attendance);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Attendance updated successfully.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to update attendance.");
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
        [Route("api/attendance/delete/{attendanceId}")]
        public HttpResponseMessage Delete(int attendanceId)
        {
            try
            {
                var isSuccess = EmployeeService.Delete(attendanceId);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Attendance terminated successfully.");
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


    }
}
