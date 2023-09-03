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
using DAL.EF;
using DAL.Migrations;
using DAL.Enums;

namespace BLL.Services
{
    public class LeaveService
    {
        public static List<LeaveDTO> Get()
        {
            var data = DataAccessFactory.LeaveData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Leave, LeaveDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<LeaveDTO>>(data);
            return converted;
        }

        public static LeaveDTO Get(int id)
        {
            var data = DataAccessFactory.LeaveData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Leave, LeaveDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<LeaveDTO>(data);
            return converted;
        }

        public static List<LeaveDTO> GetAttendancesByEmployeeId(int employeeId)
        {
            var leaveRepo = new LeaveRepo(); // Instantiate AttendanceRepo directly
            var data = leaveRepo.GetByEmployeeId(employeeId);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Leave, LeaveDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<LeaveDTO>>(data);
            return converted;
        }




        public static LeaveDTO Create(LeaveDTO leaveDTO)
        {
            try
            {
                // Calculate the number of days between StartDate and EndDate
                int numberOfDays = (int)(leaveDTO.EndDate - leaveDTO.StartDate).TotalDays;

                int employeeId = leaveDTO.EmployeeId;

                // Retrieve the latest leave entry for the employee from the database
                var leaveRepo = DataAccessFactory.LeaveData() as LeaveRepo;
                var latestLeave = leaveRepo.GetByEmployeeId(employeeId).OrderByDescending(l => l.Id).FirstOrDefault();

                int remainingLeave;

                if (latestLeave == null)
                {
                    // No previous leave entry, assume initial remaining leave balance is 20
                    remainingLeave = 20;
                }
                else
                {
                    remainingLeave = latestLeave.RemainingLeave;

                    // If the status of the new leave application is 1 (Approved), deduct the requested days from remaining leave
                    if (leaveDTO.Status == LeaveStatus.Approved)
                    {
                        remainingLeave -= numberOfDays;
                    }
                }

                // Update the remaining leave balance in the current leave application
                leaveDTO.RemainingLeave = remainingLeave;

                // Ensure that TotalAnnualLeaveEntitlement is fixed at 20 for every employee
                leaveDTO.TotalAnnualLeaveEntitlement = 20;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<LeaveDTO, Leave>();
                    cfg.CreateMap<Leave, LeaveDTO>();
                });

                var mapper = new Mapper(config);

                var leave = mapper.Map<Leave>(leaveDTO);
                var isSuccess = DataAccessFactory.LeaveData().Create(leave);

                if (isSuccess)
                {
                    var createdLeave = DataAccessFactory.LeaveData().Get(leave.Id);

                    var createdLeaveDTO = mapper.Map<LeaveDTO>(createdLeave);

                    return createdLeaveDTO;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                // Log and handle the exception
                Console.WriteLine(e.ToString()); // Log the exception details
                return null; // Return null to indicate error
            }
        }







        public static bool Update(LeaveDTO leaveDTO)
        {
            int numberOfDays = (int)(leaveDTO.EndDate - leaveDTO.StartDate).TotalDays;

            int employeeId = leaveDTO.EmployeeId;

            // Retrieve the latest leave entry for the employee from the database
            var leaveRepo = DataAccessFactory.LeaveData() as LeaveRepo;
            var latestLeave = leaveRepo.GetByEmployeeId(employeeId).OrderByDescending(l => l.Id).FirstOrDefault();

            int remainingLeave = latestLeave.RemainingLeave;
            leaveDTO.RemainingLeave = remainingLeave - numberOfDays;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LeaveDTO, Leave>();
                cfg.CreateMap<Leave, Leave>();
            });
            var mapper = new Mapper(config);

            var leave = mapper.Map<Leave>(leaveDTO);

            var isSuccess = DataAccessFactory.LeaveData().Update(leave);

            return isSuccess;
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.LeaveData().Delete(id);
            return isSuccess;
        }
    }
}
