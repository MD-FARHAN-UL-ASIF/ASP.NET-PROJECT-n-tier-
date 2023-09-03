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
    public class RawMaterialService
    {
        public static List<RawMaterialDTO> Get()
        {
            var data = DataAccessFactory.RawMaterialData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RawMaterial, RawMaterialDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<RawMaterialDTO>>(data);
            return converted;
        }

        public static RawMaterialDTO Get(int id)
        {
            var data = DataAccessFactory.RawMaterialData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RawMaterial, RawMaterialDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<RawMaterialDTO>(data);
            return converted;

        }

        public static RawMaterialDTO Create(RawMaterialDTO rawMaterialDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RawMaterialDTO, RawMaterial>();
                cfg.CreateMap<RawMaterial, RawMaterialDTO>();
            });

            var mapper = new Mapper(config);

            var rawMaterial = mapper.Map<DAL.EF.Models.RawMaterial>(rawMaterialDTO);
            var isSuccess = DataAccessFactory.RawMaterialData().Create(rawMaterial);

            if (isSuccess)
            {
                var createdRawMaterial = DataAccessFactory.RawMaterialData().Get(rawMaterial.Id);

                var createdRawMaterialDTO = mapper.Map<RawMaterialDTO>(createdRawMaterial);

                return createdRawMaterialDTO;
            }
            else
            {
                return null;
            }
        }
        public static bool Update(RawMaterialDTO rawMaterialDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RawMaterialDTO, RawMaterial>();
                cfg.CreateMap<RawMaterial, RawMaterialDTO>();
            });
            var mapper = new Mapper(config);

            var rawMaterial = mapper.Map<RawMaterial>(rawMaterialDTO);

            var isSuccess = DataAccessFactory.RawMaterialData().Update(rawMaterial);

            return isSuccess;
        }
        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.RawMaterialData().Delete(id);
            return isSuccess;
        }
    }
}
