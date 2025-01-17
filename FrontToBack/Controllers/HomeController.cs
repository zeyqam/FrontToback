﻿using FrontToBack.Data;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task< IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            string backgroundImageUrl = await _context.Images.Select(m => m.Url).FirstOrDefaultAsync();
            ViewBag.BackgroundImageUrl = backgroundImageUrl;
            return View(sliders);
        }
    }
}
