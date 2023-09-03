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
    public class ProductionPlanService
    {
        public static List<ProductionPlanDTO> Get()
        {
            var data = DataAccessFactory.PlanData().Get();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<ProductionPlan, ProductionPlanDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<ProductionPlanDTO>>(data);
            return converted;
        }

        public static ProductionPlanDTO Get(int id)
        {
            var data = DataAccessFactory.PlanData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductionPlan, ProductionPlanDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<ProductionPlanDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }
        public static ProductionPlanDTO Create(ProductionPlanDTO planDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductionPlanDTO, ProductionPlan>();
                cfg.CreateMap<ProductionPlan, ProductionPlanDTO>();
            });
            var mapper = new Mapper(config);

            var plan = mapper.Map<ProductionPlan>(planDTO);

            var isSuccess = DataAccessFactory.PlanData().Create(plan);

            if (isSuccess)
            {
                var createPlan = DataAccessFactory.PlanData().Get(plan.PlanID);

                var createPlanDTO = mapper.Map<ProductionPlanDTO>(createPlan);

                return createPlanDTO;
            }
            else
            {
                return null;
            }
        }
        public static bool Update(ProductionPlanDTO planDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductionPlanDTO, ProductionPlan>();
                cfg.CreateMap<ProductionPlan, ProductionPlanDTO>();
            });
            var mapper = new Mapper(config);

            var plan = mapper.Map<ProductionPlan>(planDTO);

            var isSuccess = DataAccessFactory.PlanData().Update(plan);

            return isSuccess;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.PlanData().Delete(id);
        }
    }
}
