using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;

namespace Test.Models
{
    public class PostModel
    {
        private readonly TestDbContext _context;
        public PostModel()
        {
            _context = new TestDbContext();
        }

        public List<Post> GetList()
        {
            return _context.Posts.ToList();
        }
    }
}
