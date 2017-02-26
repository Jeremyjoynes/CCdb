using CastleClashdb.Models.CastleClash;
using CastleClashdb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastleClashdb.Services
{
    public class UserService
    {
        private IGenericRepository repo;
        public UserService(IGenericRepository repo)
        {
            this.repo = repo;
        }
        //get users
        public IEnumerable<User> GetAllUsers()
        {
            return repo.Query<User>();
        }
        // bool version
        public bool GetUserById(int id, out User item)
        {
            item = repo.Query<User>().FirstOrDefault(m => m.Id == id);
            return item != null;
        }
        public User GetUserById(int id)
        {
            return repo.Query<User>().FirstOrDefault(m => m.Id == id);
        }

        //create
        public User SaveUser(User item)
        {
            return repo.Add<User>(item);

        }

        //update
        public void UpdateUser(int id, User item)
        {
            item.Id = id;
            repo.Update<User>(item);
        }

        //Delete 
        public void DeleteUser(int id)
        {
            var item = repo.Query<User>().FirstOrDefault(m => m.Id == id);
            repo.Delete<User>(item);
        }

        //Cleanup
        public void Dispose()
        {
            repo.Dispose();
        }
    }
}
