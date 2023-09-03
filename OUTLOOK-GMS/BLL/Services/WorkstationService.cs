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
    public class WorkstationService
    {
        public static List<WorkstationDTO> Get()
        {
            var data = DataAccessFactory.WorkData().Get();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Workstation, WorkstationDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<WorkstationDTO>>(data);
            return converted;
        }

        public static WorkstationDTO Get(int id)
        {
            var data = DataAccessFactory.WorkData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Workstation, WorkstationDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<WorkstationDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }
        public static WorkstationDTO Create(WorkstationDTO workDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WorkstationDTO, Workstation>();
                cfg.CreateMap<Workstation, WorkstationDTO>();
            });
            var mapper = new Mapper(config);

            var workstation = mapper.Map<Workstation>(workDTO);

            var isSuccess = DataAccessFactory.WorkData().Create(workstation);

            if (isSuccess)
            {
                var createWork = DataAccessFactory.WorkData().Get(workstation.WorkstationID);

                var createWorkDTO = mapper.Map<WorkstationDTO>(createWork);

                return createWorkDTO;
            }
            else
            {
                return null;
            }
        }
        public static bool Update(WorkstationDTO workDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WorkstationDTO, Workstation>();
                cfg.CreateMap<WorkstationDTO, WorkstationDTO>();
            });
            var mapper = new Mapper(config);

            var workstation = mapper.Map<Workstation>(workDTO);

            var isSuccess = DataAccessFactory.WorkData().Update(workstation);

            return isSuccess;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.WorkData().Delete(id);
        }
    }
}
