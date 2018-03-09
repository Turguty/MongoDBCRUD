using WebApplication1.DataLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Model;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace WebApplication1.DataLayer
{
    public class UsersService : IUsersService
    {
        private readonly MongoRepository _repository = null;
        public UsersService(IOptions<Settings> settings)
        {
            _repository = new MongoRepository(settings);
        }

        public async Task<IEnumerable<Users>> GetAllUser()
        {
            return await _repository.users.Find(x => true).ToListAsync();
        }

        public async Task<Users> GetUser(string name)
        {
            var filter = Builders<Users>.Filter.Eq("Name", name);
            return await _repository.users.Find(filter).FirstOrDefaultAsync();
        }
        public async Task AddUser(Users model)
        {
            //inserting data
            await _repository.users.InsertOneAsync(model);
        }

        public async Task<bool> UpdatePassword(Users model)
        {

            var filter = Builders<Users>.Filter.Eq("Name", model.Name);
            var user = _repository.users.Find(filter).FirstOrDefaultAsync();
            if (user.Result == null)
                return false;
            var update = Builders<Users>.Update
                                          .Set(x => x.Password, model.Password)
                                          .Set(x => x.UpdatedOn, model.UpdatedOn);

            await _repository.users.UpdateOneAsync(filter, update);
            return true;
        }

        public async Task<DeleteResult> RemoveUser(string name)
        {
            var filter = Builders<Users>.Filter.Eq("Name", name);
            return await _repository.users.DeleteOneAsync(filter);
        }
        public async Task<DeleteResult> RemoveAllUser()
        {
            return await _repository.users.DeleteManyAsync(new BsonDocument());
        }
    }
    
}
