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
    public class NoticeService
    {
        public static List<NoticeDTO> Get()
        {
            var data = DataAccessFactory.NoticeData().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<NoticeDTO>>(data);
            return cnvrted;
        }
        public static NoticeDTO Get(int id)
        {
            var data = DataAccessFactory.NoticeData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<NoticeDTO>(data);
            return cnvrted;
        }
        public static NoticeDTO Create(NoticeDTO noticeDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NoticeDTO, Notice>();
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);

            var notice = mapper.Map<Notice>(noticeDTO);

            // Call the data access layer to create an order
            var isSuccess = DataAccessFactory.NoticeData().Create(notice);

            if (isSuccess)
            {
                // If creation was successful, retrieve the created order (if needed)
                var createdNotice = DataAccessFactory.NoticeData().Get(notice.Id);

                // Map the created order back to OrderDTO (if needed)
                var createdNoticeDTO = mapper.Map<NoticeDTO>(createdNotice);

                return createdNoticeDTO;
            }
            else
            {
                // Handle creation failure, perhaps by throwing an exception or returning null
                return null;
            }
        }
        public static bool Update(NoticeDTO noticeDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NoticeDTO, Notice>();
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);

            var notice = mapper.Map<Notice>(noticeDTO);

            var isSuccess = DataAccessFactory.NoticeData().Update(notice);

            return isSuccess;
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.NoticeData().Delete(id);
            return isSuccess;
        }

    }
}
