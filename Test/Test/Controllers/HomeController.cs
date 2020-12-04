using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestDbContext _context;


        public HomeController(ILogger<HomeController> logger, TestDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<IActionResult> Index(string id)
        {
            if(id == null)
            {
                var catename = await _context.Posts.Select(x => new PostDto
                {
                    PostId = x.PostId,
                    PostTitle = x.PostTitle,
                    CategoryId = x.CategoryId,
                    PostDescription = x.PostDescription,
                    DateCreated = x.DateCreated,
                    DateUpdate = x.DateUpdate,
                    CategoryName = x.Category.CategoryName
                }).ToListAsync();
                return View(catename);
            } 
            else
            {
                var catename = await _context.Posts.Select(x => new PostDto
                {
                    PostId = x.PostId,
                    PostTitle = x.PostTitle,
                    CategoryId = x.CategoryId,
                    PostDescription = x.PostDescription,
                    DateCreated = x.DateCreated,
                    DateUpdate = x.DateUpdate,
                    CategoryName = x.Category.CategoryName
                }).Where(x => x.CategoryId == int.Parse(id)).ToListAsync();
                return View(catename);
            }    
           
        }

        public async Task<IActionResult> listCategories()
        {
            var item = new CategoryModel().GetListCategory();
            return View(await _context.Categories.ToListAsync());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

    }
}
