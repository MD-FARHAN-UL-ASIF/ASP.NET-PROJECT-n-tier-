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
    public class NoticeController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [HttpPost]
        [Route("api/notice/create")]
        public HttpResponseMessage Create(NoticeDTO notice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = NoticeService.Create(notice);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Notice created successfully.");
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
        [Route("api/notice/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = NoticeService.Get();
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
        [Route("api/notice/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = NoticeService.Get(id);
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


        [HttpPut]
        [Route("api/notice/update/{id}")]
        public HttpResponseMessage Update(int id, NoticeDTO notice)
        {
            if (notice is null)
            {
                throw new ArgumentNullException(nameof(notice));
            }

            try
            {
                if (ModelState.IsValid)
                {
                    notice.Id = id;
                    var isSuccess = NoticeService.Update(notice);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Notice updated successfully.");
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
        [Route("api/notice/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = NoticeService.Delete(id);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Notice deleted successfully.");
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
