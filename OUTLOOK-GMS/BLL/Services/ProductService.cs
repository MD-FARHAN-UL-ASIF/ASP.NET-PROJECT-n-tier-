using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        public static List<ProductDTO> Get()
        {
            var data = DataAccessFactory.ProductData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<ProductDTO>>(data);
            return converted;
        }

        public static ProductDTO Get(int id)
        {
            var data = DataAccessFactory.ProductData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<ProductDTO>(data);
            return converted;
        }

        public static ProductDTO Create(ProductDTO productDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<Product, ProductDTO>();
            });

            var mapper = new Mapper(config);

            var product = mapper.Map<DAL.EF.Models.Product>(productDTO);
            var isSuccess = DataAccessFactory.ProductData().Create(product);

            if (isSuccess)
            {
                var createdProduct = DataAccessFactory.ProductData().Get(product.Id);

                var createdProductDTO = mapper.Map<ProductDTO>(createdProduct);

                return createdProductDTO;
            }
            else
            {
                return null;
            }
        }
        public static bool Update(ProductDTO productDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);

            var product = mapper.Map<Product>(productDTO);

            var isSuccess = DataAccessFactory.ProductData().Update(product);

            return isSuccess;


        }
        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.ProductData().Delete(id);
            return isSuccess;
        }

    }
}
