using CastleClashdb.Models.CastleClash;
using CastleClashdb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastleClashdb.Services
{
    public class HeroService : IDisposable
    {
        private IGenericRepository repo;
        public HeroService(IGenericRepository repo)
        {
            this.repo = repo;
        }
        //get heroes
        public IEnumerable<Hero> GetAllHeroes()
        {
            return repo.Query<Hero>();
        }
        // bool version
        public bool GetHeroById(int id, out Hero item)
        {
            item = repo.Query<Hero>().FirstOrDefault(m => m.Id == id);
            return item != null;
        }
        public Hero GetHeroById(int id)
        {
            return repo.Query<Hero>().FirstOrDefault(m => m.Id == id);
        }

        //create
        public Hero SaveHero(Hero item)
        {
            return repo.Add<Hero>(item);
                
        }

        //update
        public void UpdateHero(int id, Hero item)
        {
            item.Id = id;
            repo.Update<Hero>(item);
        }

        //Delete 
        public void DeleteHero(int id)
        {
            var item = repo.Query<Hero>().FirstOrDefault(m => m.Id == id);
            repo.Delete<Hero>(item);
        }
            
        //Cleanup
        public void Dispose()
        {
            repo.Dispose();
        }
    }
}
