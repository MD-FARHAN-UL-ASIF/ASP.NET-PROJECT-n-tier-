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

    public class RawMaterialController : ApiController
    {
        [HttpPost]
        [Route("api/rawmaterial/create")]
        public HttpResponseMessage Create(RawMaterialDTO rawmaterial)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = RawMaterialService.Create(rawmaterial);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "News item created successfully.");
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
        [Route("api/rawmaterial/viewall")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = RawMaterialService.Get();
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
        [Route("api/rawmaterial/view/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = RawMaterialService.Get(id);
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
        [Route("api/rawmaterial/update")]
        public HttpResponseMessage Update(RawMaterialDTO rawmaterial
           )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isSuccess = RawMaterialService.Update(rawmaterial);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Rawmaterial information updated successfully.");
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
        [Route("api/rawmaterial/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = RawMaterialService.Delete(id);



                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Rawmaterial deleted successfully.");
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
