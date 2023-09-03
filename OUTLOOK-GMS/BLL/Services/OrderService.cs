using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService
    {
        public static List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderData().Get();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<OrderDTO>>(data);
            return converted;
        }

        public static OrderDTO Get(int id)
        {
            var data = DataAccessFactory.OrderData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<OrderDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }
        public static OrderDTO Create(OrderDTO orderDTO)
        {
            orderDTO.OrderDate = DateTime.Now;
            orderDTO.OrderStatus = (DAL.Enums.OrderStatus)1;
            orderDTO.TaxAmount = orderDTO.TotalAmount * 0.3m / 100;
            orderDTO.ShippingCost = 60.00m;
            var Discounts = orderDTO.Discounts / 100;
            var DiscountsAmount = orderDTO.TotalAmount - (orderDTO.TotalAmount * Discounts);
            orderDTO.TotalAmount = orderDTO.ShippingCost + orderDTO.TaxAmount + orderDTO.TotalAmount - DiscountsAmount;
            orderDTO.PaymentStatus = (DAL.Enums.PaymentStatus)1;
            orderDTO.ShippingMethod = 0;
            orderDTO.ExpectedDeliveryDate = DateTime.Now.AddDays(5);
            orderDTO.TrackingNumber = new Random().Next(1, 10000).ToString();
            orderDTO.OrderPriority = (DAL.Enums.OrderPriority)1;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);

            var order = mapper.Map<Order>(orderDTO);

            var isSuccess = DataAccessFactory.OrderData().Create(order);

            if (isSuccess)
            {
                var createOrder = DataAccessFactory.OrderData().Get(order.OrderID);

                var createOrderDTO = mapper.Map<OrderDTO>(createOrder);

                return createOrderDTO;
            }
            else
            {
                return null;
            }
        }
        public static bool Update(OrderDTO orderDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);

            var order = mapper.Map<Order>(orderDTO);

            var isSuccess = DataAccessFactory.OrderData().Update(order);

            return isSuccess;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.OrderData().Delete(id);
        }
        public static List<OrderDTO> GetByCustomer(int id)
        {
            var data = DataAccessFactory.CustomerOrderData().GetByCustomer(id);
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<OrderDTO>>(data);
            return converted;
        }


    }
}
