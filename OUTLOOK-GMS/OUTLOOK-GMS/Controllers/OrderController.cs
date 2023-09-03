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
    public class OrderController : ApiController
    {
        [HttpPost]
        [Route("api/order/create")]
        public HttpResponseMessage Create(OrderDTO orderDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = OrderService.Create(orderDTO);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Order created successfully.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Order creation failed!");
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
        [Route("api/order")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = OrderService.Get();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Order not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpGet]
        [Route("api/order/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = OrderService.Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Order not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("api/order/update/{id}")]
        public HttpResponseMessage Update(int id, OrderDTO orderDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Set the ID of the order to be updated
                    orderDTO.OrderID = id;

                    var isSuccess = OrderService.Update(orderDTO);

                    if (isSuccess)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Order updated successfully.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Order not found!");
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
        [Route("api/order/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = OrderService.Delete(id);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Order deleted successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Order not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("api/order/cusor/{id}")]
        public HttpResponseMessage GetByCustomer(int id)
        {
            try
            {
                var data = OrderService.GetByCustomer(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Order not found!");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
