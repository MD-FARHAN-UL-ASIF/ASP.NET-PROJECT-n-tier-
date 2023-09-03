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
    public class ProductionPlanController : ApiController
    {
        [HttpPost]
        [Route("api/plan/create")]
        public HttpResponseMessage Create(ProductionPlanDTO planDTO)
        {
            try
            {
                var data = ProductionPlanService.Create(planDTO);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Production Plan created successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Production Plan creation failed!");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/plan")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ProductionPlanService.Get();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Production Plan not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpGet]
        [Route("api/plan/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = ProductionPlanService.Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Production Plan not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/plan/update/{id}")]
        public HttpResponseMessage Update(int id, ProductionPlanDTO planDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Set the ID of the order to be updated
                    planDTO.PlanID = id;

                    var isSuccess = ProductionPlanService.Update(planDTO);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Production Plan updated successfully.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Production Plan not found!");
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
        [Route("api/plan/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = ProductionPlanService.Delete(id);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Production Plan deleted successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Production Plan not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
