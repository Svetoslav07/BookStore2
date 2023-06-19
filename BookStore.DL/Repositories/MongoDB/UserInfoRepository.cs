using BookStore.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.Repositories.MongoDB
{
    public class UserInfoRepository
    {
        private readonly IMongoCollection<UserInfo> _userInfo;
    }

    public UserInfoMongoRepository(IOptionsMonitor<MongoDbConfiguration>mongoConfig)
    {
        var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);

        var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

        _userInfo = database.GetCollection<UserInfo>(nameof(UserInfo));
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _userInfo.Find(u => u.Username==UsernamePasswordCredential && u.Password == password).FirstOrDefaultAsync();
    }


}
