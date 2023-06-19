using BookStore.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Services
{
    public class UserInfoServices : IUserInfoRepository
    {
        private readonly IUserInfoRepository _userInfoRepository;
        
        public UserInfoRepository(IUserInfoRepository userInfroRepositor
        {
            _userInfoRepository = userInfroRepository;  
        }
    }

    public async Task<UserInfo?> GetUserInfo(string username, string password)
    {
        return await_userInfoRepository.GetUserInfo(username, password);
    }
}
