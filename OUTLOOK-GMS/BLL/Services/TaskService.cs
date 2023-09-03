using AutoMapper;
using BLL.DTOs;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TaskService
    {
        public static List<TaskDTO> Get()
        {
            var data = DataAccessFactory.TaskData().Get();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<DAL.EF.Models.Task, TaskDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<TaskDTO>>(data);
            return converted;
        }

        public static TaskDTO Get(int id)
        {
            var data = DataAccessFactory.TaskData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DAL.EF.Models.Task, TaskDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<TaskDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }
        public static TaskDTO Create(TaskDTO taskDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskDTO, DAL.EF.Models.Task>();
                cfg.CreateMap<DAL.EF.Models.Task, TaskDTO>();
            });
            var mapper = new Mapper(config);

            var task = mapper.Map<DAL.EF.Models.Task>(taskDTO);

            var isSuccess = DataAccessFactory.TaskData().Create(task);

            if (isSuccess)
            {
                var createTask = DataAccessFactory.TaskData().Get(task.TaskID);

                var createTaskDTO = mapper.Map<TaskDTO>(createTask);

                return createTaskDTO;
            }
            else
            {
                return null;
            }
        }
        public static bool Update(TaskDTO taskDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskDTO, DAL.EF.Models.Task>();
                cfg.CreateMap<DAL.EF.Models.Task, TaskDTO>();
            });
            var mapper = new Mapper(config);

            var task = mapper.Map<DAL.EF.Models.Task>(taskDTO);

            var isSuccess = DataAccessFactory.TaskData().Update(task);

            return isSuccess;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.TaskData().Delete(id);
        }
    }
}
