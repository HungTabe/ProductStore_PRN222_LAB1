using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO _categoryDAO;

        public CategoryRepository(CategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }

        public List<Category> GetCategories() => _categoryDAO.GetCategories();
        public Category GetCategoryById(int id) => _categoryDAO.GetCategoryById(id);
        public void AddCategory(Category category) => _categoryDAO.AddCategory(category);
        public void UpdateCategory(Category category) => _categoryDAO.UpdateCategory(category);
        public void DeleteCategory(int id) => _categoryDAO.DeleteCategory(id);
    }
}
