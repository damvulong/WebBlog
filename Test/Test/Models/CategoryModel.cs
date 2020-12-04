using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;

namespace Test.Models
{
    public class CategoryModel
    {
        private readonly TestDbContext _context;
        public CategoryModel()
        {
            _context = new TestDbContext();
        }

        public List<Category> GetListCategory()
        {
            return _context.Categories.ToList();
        }
    }
}
