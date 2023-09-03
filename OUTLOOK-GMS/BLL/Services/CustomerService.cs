using AutoMapper;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using Newtonsoft.Json;

namespace BLL.Services
{
    public class CustomerService
    {
        public static List<CustomerDTO> Get()
        {
            var data = DataAccessFactory.CoustomerData().Get();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<CustomerDTO>>(data);
            return converted;
        }

        public static CustomerDTO Get(int id)
        {
            var data = DataAccessFactory.CoustomerData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<CustomerDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }
        public static CustomerDTO Create(CustomerDTO customerDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);

            var customer = mapper.Map<Customer>(customerDTO);

            var isSuccess = DataAccessFactory.CoustomerData().Create(customer);

            if (isSuccess)
            {
                var createCustomer = DataAccessFactory.CoustomerData().Get(customer.CustomerID);

                var createCustomerDTO = mapper.Map<CustomerDTO>(createCustomer);

                return createCustomerDTO;
            }
            else
            {
                return null;
            }
        }
        public static bool Update(CustomerDTO customerDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);

            var customer = mapper.Map<Customer>(customerDTO);

            var isSuccess = DataAccessFactory.CoustomerData().Update(customer);

            return isSuccess;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CoustomerData().Delete(id);
        }
    }
}
