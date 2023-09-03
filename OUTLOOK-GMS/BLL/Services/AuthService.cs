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
    public class AuthService
    {
        public static TokenDTO Login(string email, string password)
        {
            var employee = DataAccessFactory.AuthData().Authenticate(email, password);
            if (employee != null)
            {
                var token = new Token();
                token.TokenKey = Guid.NewGuid().ToString();
                token.EmployeeId = employee.Id;
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;
                var tk = DataAccessFactory.TokenData().Create(token);
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(config);
                var data = mapper.Map<TokenDTO>(tk);
                return data;
            }
            return null;
        }
        public static bool IsTokenValid(string token)
        {
            var tk = (from t in DataAccessFactory.TokenData().Get()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      select t).SingleOrDefault();
            if (tk != null)
            {
                return true;
            }
            return false;
        }
    }
}
