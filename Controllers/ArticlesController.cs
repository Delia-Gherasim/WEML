using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElderyPeopleCare.Data;
using ElderyPeopleCare.Models;
using ElderyPeopleCare.Service;

namespace ElderyPeopleCare.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private HealthArticlesService _articlesService;

        public ArticlesController(ApplicationDbContext context)
        {
            _articlesService = new HealthArticlesService();
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _articlesService.GetArticlesAsync("headache"));
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await _articlesService.GetArticlesAsync("headache");
            var article = articles.FirstOrDefault(a => a.Uri == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

       
    }
}
