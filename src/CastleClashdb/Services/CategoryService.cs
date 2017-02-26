using CastleClashdb.Models.CastleClash;
using CastleClashdb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastleClashdb.Services
{
    public class CategoryService : IDisposable
    {
        private IGenericRepository repo;
        public CategoryService(IGenericRepository repo)
        {
            this.repo = repo;
        }
        //get categories
        public IEnumerable<Category> GetAllCategories()
        {
            return repo.Query<Category>();
        }

        //boolean version
        public bool GetCategoryById(int id, out Category item)
        {
            item = repo.Query<Category>().FirstOrDefault(x => x.Id == id);
            return item != null;
        }

        public Category GetCategoryById(int id)
        {
            return repo.Query<Category>().FirstOrDefault(x => x.Id == id);
        }

        //create
        public Category SaveCategory(Category item)
        {
            return repo.Add<Category>(item);
        }

        //update
        public void UpdateCategory(int id, Category item)
        {
            item.Id = id;
            repo.Update<Category>(item);
        }
        //delete

        public void DeleteCategory(int id)
        {
            var item = repo.Query<Category>().FirstOrDefault(x => x.Id == id);
            repo.Delete<Category>(item);
        }

        public void Dispose()
        {
            repo.Dispose();
        }
    }
}
