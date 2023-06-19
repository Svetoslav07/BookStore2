using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.Interfaces
{
    public interface IUserInfoRepository
    {
         Task<UserInfo?>GetUserInfo(string email, string password);
    }
}
