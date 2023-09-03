using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using DAL.Repo;

namespace BLL.Services
{
    public class AttendanceService
    {
        public static List<AttendanceDTO> Get()
        {
            var data = DataAccessFactory.AttendanceData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Attendance, AttendanceDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<AttendanceDTO>>(data);
            return cnvrted;
        }
        public static AttendanceDTO Get(int attendanceId)
        {
            var data = DataAccessFactory.AttendanceData().Get(attendanceId);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeDTO>(); // Add mapping for Employee to EmployeeDTO if needed
                cfg.CreateMap<Attendance, AttendanceDTO>()
                    .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee));
            });

            var mapper = new Mapper(config);
            var converted = mapper.Map<AttendanceDTO>(data);
            return converted;
        }

        public static List<AttendanceDTO> GetAttendancesByEmployeeId(int employeeId)
        {
            var attendanceRepo = new AttendanceRepo(); // Instantiate AttendanceRepo directly
            var data = attendanceRepo.GetByEmployeeId(employeeId);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Attendance, AttendanceDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<AttendanceDTO>>(data);
            return converted;
        }

        public static List<AttendanceDTO> GetAttendancesByDate(DateTime date)
        {
            var attendanceRepo = new AttendanceRepo(); // Instantiate AttendanceRepo directly
            var data = attendanceRepo.GetByDate(date);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Attendance, AttendanceDTO>();
            });

            var mapper = config.CreateMapper(); // Create mapper instance

            var converted = mapper.Map<List<AttendanceDTO>>(data);
            return converted;
        }
        public static AttendanceDTO Create(AttendanceDTO attendanceDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AttendanceDTO, Attendance>();
                cfg.CreateMap<Attendance, AttendanceDTO>();
            });
            var mapper = new Mapper(config);

            var attendance = mapper.Map<Attendance>(attendanceDTO);

            // Call the data access layer to create an order
            var isSuccess = DataAccessFactory.AttendanceData().Create(attendance);

            if (isSuccess)
            {
                // If creation was successful, retrieve the created order (if needed)
                var createdAttendance = DataAccessFactory.AttendanceData().Get(attendance.AttendanceId);

                // Map the created order back to OrderDTO (if needed)
                var createdAttendanceDTO = mapper.Map<AttendanceDTO>(createdAttendance);

                return createdAttendanceDTO;
            }
            else
            {
                // Handle creation failure, perhaps by throwing an exception or returning null
                return null;
            }
        }
        public static bool Update(AttendanceDTO attendanceDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AttendanceDTO, Attendance>();
                cfg.CreateMap<Attendance, AttendanceDTO>();
            });
            var mapper = new Mapper(config);

            var attendance = mapper.Map<Attendance>(attendanceDTO);

            var isSuccess = DataAccessFactory.AttendanceData().Update(attendance);

            return isSuccess;
        }

        public static bool Delete(int attendanceId)
        {
            var isSuccess = DataAccessFactory.AttendanceData().Delete(attendanceId);
            return isSuccess;
        }
    }
}

