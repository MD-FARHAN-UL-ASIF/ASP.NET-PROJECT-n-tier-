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
    public class EmployeeController : ApiController
    {
       
        [HttpPost]
        [Route("api/employee/create")]
        public HttpResponseMessage Create(EmployeeDTO employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = EmployeeService.Create(employee);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Employee created successfully.");
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
        [Route("api/employee/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = EmployeeService.Get();
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
        [Route("api/employee/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = EmployeeService.Get(id);
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
        [Route("api/employee/byname/{name}")]
        public HttpResponseMessage GetByName(String name)
        {
            try
            {
                var employees = EmployeeService.GetEmployeeByName(name);
                if (employees != null && employees.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employees);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No employee records found for the specified name.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/employee/update/{id}")]
        public HttpResponseMessage Update(int id, EmployeeDTO employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            try
            {
                if (ModelState.IsValid)
                {
                    employee.Id = id;
                    var isSuccess = EmployeeService.Update(employee);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Employee updated successfully.");
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

        [HttpDelete]
        [Route("api/employee/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = EmployeeService.Delete(id);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee terminated successfully.");
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
