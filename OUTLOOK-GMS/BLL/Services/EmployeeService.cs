using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {

        public static List<EmployeeDTO> Get()
        {
            var data = DataAccessFactory.EmployeeData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<EmployeeDTO>>(data);
            return cnvrted;
        }
        
        public static EmployeeDTO Get(int id)
        {
            var data = DataAccessFactory.EmployeeData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Attendance, AttendanceDTO>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<EmployeeDTO>(data);
            return cnvrted;
        }



        public static List<EmployeeDTO> GetEmployeeByName(String name)
        {
            var employeeRepo = new EmployeeRepo(); // Instantiate AttendanceRepo directly
            var data = employeeRepo.GetByName(name);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });

            var mapper = config.CreateMapper(); // Create mapper instance

            var converted = mapper.Map<List<EmployeeDTO>>(data);
            return converted;
        }


        public static EmployeeDTO Create(EmployeeDTO employeeDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);

            var employee = mapper.Map<Employee>(employeeDTO);

            // Call the data access layer to create an order
            var isSuccess = DataAccessFactory.EmployeeData().Create(employee);

            if (isSuccess)
            {
                // If creation was successful, retrieve the created order (if needed)
                var createdEmployee = DataAccessFactory.EmployeeData().Get(employee.Id);

                // Map the created order back to OrderDTO (if needed)
                var createdEmployeeDTO = mapper.Map<EmployeeDTO>(createdEmployee);

                return createdEmployeeDTO;
            }
            else
            {
                // Handle creation failure, perhaps by throwing an exception or returning null
                return null;
            }
        }
        public static bool Update(EmployeeDTO employeeDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);

            var employee = mapper.Map<Employee>(employeeDTO);

            var isSuccess = DataAccessFactory.EmployeeData().Update(employee);

            return isSuccess;
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.EmployeeData().Delete(id);
            return isSuccess;
        }
    }
}
