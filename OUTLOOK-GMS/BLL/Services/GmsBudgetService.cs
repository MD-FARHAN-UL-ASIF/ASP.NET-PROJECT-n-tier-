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
    public class GmsBudgetService
    {
        //viewall
        public static List<GmsBudgetDTO> Get()
        {
            var data = DataAccessFactory.GmsBudgetData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GmsBudget, GmsBudgetDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<GmsBudgetDTO>>(data);
            return converted;
        }



        // Get by Id
        public static GmsBudgetDTO Get(int id)
        {
            var data = DataAccessFactory.GmsBudgetData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GmsBudget, GmsBudgetDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<GmsBudgetDTO>(data);
            return converted;
        }

        //create
        public static GmsBudgetDTO Create(GmsBudgetDTO gmsbudgetDTO)
        {
            //Calculate allocated amounts based on user-defined percentages
            decimal totalBudget = gmsbudgetDTO.BudgetAmount;
            decimal salaryPercentage = gmsbudgetDTO.SalaryPercentage; // Assuming DTO has this property
            decimal productionPercentage = gmsbudgetDTO.ProductionPercentage; // Assuming DTO has this property
            decimal otherExpensesPercentage = gmsbudgetDTO.OtherExpensesPercentage; // Assuming DTO has this property

            decimal salaryAllocation = totalBudget * (salaryPercentage / 100);
            decimal productionAllocation = totalBudget * (productionPercentage / 100);
            decimal otherExpensesAllocation = totalBudget * (otherExpensesPercentage / 100);
            decimal remainingBudget = totalBudget - (salaryAllocation + productionAllocation + otherExpensesAllocation);

            // Update the gmsbudgetDTO with calculated values
            gmsbudgetDTO.SalaryAllocation = salaryAllocation;
            gmsbudgetDTO.ProductionAllocation = productionAllocation;
            gmsbudgetDTO.OtherExpensesAllocation = otherExpensesAllocation;
            gmsbudgetDTO.RemainingBudget = remainingBudget;
            gmsbudgetDTO.RemainingAmount = gmsbudgetDTO.RemainingBudget;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GmsBudgetDTO, GmsBudget>();
                cfg.CreateMap<GmsBudget, GmsBudgetDTO>();
            });

            var mapper = new Mapper(config);
            var budget = mapper.Map<GmsBudget>(gmsbudgetDTO);
            var isSuccess = DataAccessFactory.GmsBudgetData().Create(budget);
            if (isSuccess)
            {
                var createdBudget = DataAccessFactory.GmsBudgetData().Get(budget.Id);

                var createdBudgetDTO = mapper.Map<GmsBudgetDTO>(createdBudget);

                return createdBudgetDTO;
            }
            else
            {
                return null;
            }
        }

        //Update
        public static bool Update(GmsBudgetDTO budgetDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GmsBudgetDTO, GmsBudget>();
                cfg.CreateMap<GmsBudget, GmsBudgetDTO>();

            });

            var mapper = new Mapper(config);
            var budget = mapper.Map<GmsBudget>(budgetDTO);

            var isSuccess = DataAccessFactory.GmsBudgetData().Update(budget);

            return isSuccess;
        }

        //Delete
        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.GmsBudgetData().Delete(id);
            return isSuccess;
        }
    }
}
