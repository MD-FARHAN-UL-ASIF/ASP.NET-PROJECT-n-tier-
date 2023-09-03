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
    public class GmsBudgetController : ApiController
    {
        [HttpPost]
        [Route("api/budget/create")]
        public HttpResponseMessage Create(GmsBudgetDTO gmsbudgetDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = GmsBudgetService.Create(gmsbudgetDTO);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Budget created successfully.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model state invalid");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/budget/viewall")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = GmsBudgetService.Get();
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
        [Route("api/budget/view/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = GmsBudgetService.Get(id);
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

        [HttpPost]
        [Route("api/budget/update")]
        public HttpResponseMessage Update(GmsBudgetDTO gmsbudget)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isSuccess = GmsBudgetService.Update(gmsbudget);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Budget information updated successfully.");
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
        [Route("api/budget/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = GmsBudgetService.Delete(id);



                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Budget deleted successfully.");
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
