using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories() => _categoryRepository.GetCategories();
        public Category GetCategoryById(int id) => _categoryRepository.GetCategoryById(id);
        public void AddCategory(Category category) => _categoryRepository.AddCategory(category);
        public void UpdateCategory(Category category) => _categoryRepository.UpdateCategory(category);
        public void DeleteCategory(int id) => _categoryRepository.DeleteCategory(id);
    }
}
