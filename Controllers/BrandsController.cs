using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PZ.Models;

namespace PZ.Controllers
{
    public class BrandsController : Controller
    {
        private readonly AppDbContext _context;
        public BrandsController(AppDbContext context)
        {
            _context = context;
        }

        private async Task<List<Brands>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult> GetBrandsAllJson()
        {
            return Json(await GetBrands());
        }
    }
}