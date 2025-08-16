using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pub_Mangement.Data;    // adjust if your DbContext namespace differs
using Pub_Mangement.Models;

namespace Pub_Mangement.Controllers
{
    [Route("admin/menu")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        private const int PageSize = 10;

        public AdminController(AppDbContext db) => _db = db;

        // GET: /admin/menu
        [HttpGet("")]
        public async Task<IActionResult> Index(string? q, Enums.MenuCategory? category, int page = 1)
        {
            var query = _db.MenuItems.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(m => m.Name.Contains(q));

            if (category.HasValue)
                query = query.Where(m => m.Category == category.Value);

            var total = await query.CountAsync();
            var items = await query
                .OrderBy(m => m.Name)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            ViewBag.Query = q ?? string.Empty;
            ViewBag.Category = category;
            ViewBag.Page = page;
            ViewBag.TotalPages = (int)Math.Ceiling(total / (double)PageSize);

            return View(items);
        }

        // GET: /admin/menu/create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new MenuItem());
        }

        // POST: /admin/menu/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Category")] MenuItem model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _db.MenuItems.Add(model);
            await _db.SaveChangesAsync();

            TempData["Success"] = $"Added '{model.Name}'.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /admin/menu/edit/5
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _db.MenuItems.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: /admin/menu/edit/5
        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuItemId,Name,Price,Category")] MenuItem model)
        {
            if (id != model.MenuItemId) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            var existing = await _db.MenuItems.AsNoTracking().FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (existing == null) return NotFound();

            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            TempData["Success"] = $"Updated '{model.Name}'.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /admin/menu/details/5
        [HttpGet("details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _db.MenuItems.FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (item == null) return NotFound();
            return View(item);
        }

        // GET: /admin/menu/delete/5
        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.MenuItems.FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: /admin/menu/delete/5
        [HttpPost("delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _db.MenuItems.FindAsync(id);
            if (item == null) return NotFound();

            _db.MenuItems.Remove(item);
            await _db.SaveChangesAsync();

            TempData["Success"] = $"Deleted '{item.Name}'.";
            return RedirectToAction(nameof(Index));
        }
    }
}
