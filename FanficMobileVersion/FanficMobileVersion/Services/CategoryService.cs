using FanficMobileVersion.Models;
using FanficMobileVersion.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FanficMobileVersion.Services
{
    public class CategoryService
    {
       
        public CategoryRepository _category;
        
        public async Task<IEnumerable<Category>> AllCategories()
        {
            return await _category.GetAllCategories();
        }

        public async Task<List<string>> AllCategoriesName()
        {
            return await _category.GetAllName();
        }

        public async Task<Category> CategorieById(int id)
        {
            return await _category.GetCategorieById(id);
        }

        public async Task<IEnumerable<Fanfic>> AllFanficsInCategory(int id)
        {
            return await _category.GetAllFanficsInCategory(id);
        }
    }
}
