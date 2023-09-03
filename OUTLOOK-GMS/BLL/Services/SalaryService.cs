using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repo;

namespace BLL.Services
{
    public class SalaryService
    {
        public static List<SalaryDTO> Get()
        {
            var data = DataAccessFactory.SalaryData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Salary, SalaryDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<SalaryDTO>>(data);
            return converted;
        }

        //Get by id
        public static SalaryDTO Get(int id)
        {
            var data = DataAccessFactory.SalaryData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Salary, SalaryDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<SalaryDTO>(data);
            return converted;
        }

        //create
        public static SalaryDTO Create(SalaryDTO salaryDTO)
        {
            // Determine the tax rate based on the Amount
            decimal taxRate;
            if (salaryDTO.Amount > 30000)
            {
                taxRate = 0.15m; // 15% as a decimal
            }
            else
            {
                taxRate = 0.08m; // 8% as a decimal
            }

            // Calculate tax and allowance based on the determined taxRate
            decimal tax = taxRate * salaryDTO.Amount;
            decimal allowanceRate = 0.07m; // 7% as a decimal
            decimal allowance = allowanceRate * salaryDTO.Amount;

            // Perform the arithmetic calculations
            decimal net = salaryDTO.Amount + salaryDTO.Bonus + allowance - tax;

            // Update the SalaryDTO object properties
            salaryDTO.Tax = tax;
            salaryDTO.Allowance = allowance;
            salaryDTO.Net = net;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SalaryDTO, Salary>();
                cfg.CreateMap<Salary, SalaryDTO>();
            });

            var mapper = new Mapper(config);

            var salary = mapper.Map<DAL.EF.Models.Salary>(salaryDTO);
            var isSuccess = DataAccessFactory.SalaryData().Create(salary);

            if (isSuccess)
            {
                var createdsalary = DataAccessFactory.SalaryData().Get(salary.Id);

                var createdSalaryDTO = mapper.Map<SalaryDTO>(createdsalary);

                return createdSalaryDTO;
            }
            else
            {
                return null;
            }
        }

        //Update
        public static bool Update(SalaryDTO salaryDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SalaryDTO, Salary>();
                cfg.CreateMap<Salary, SalaryDTO>();
            });
            var mapper = new Mapper(config);

            var salary = mapper.Map<Salary>(salaryDTO);

            var isSuccess = DataAccessFactory.SalaryData().Update(salary);
            return isSuccess;

        }
        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.SalaryData().Delete(id);
            return isSuccess;
        }

        public static List<SalaryDTO> GetSalariesByEmployeeId(int employeeId)
        {
            var SalaryRepo = new SalaryRepo(); // Instantiate AttendanceRepo directly
            var data = SalaryRepo.GetByEmployeeId(employeeId);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Salary, SalaryDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<SalaryDTO>>(data);
            return converted;
        }

    }
}
