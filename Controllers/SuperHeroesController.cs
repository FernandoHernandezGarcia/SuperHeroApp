using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperHeroApp.Data;
using SuperHeroApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroApp.Controllers
{
    [Authorize]
    public class SuperHeroesController : Controller
    {
        private readonly AppDbContext _context;

        public SuperHeroesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SuperHeroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet]
        public IActionResult SuperHeroes_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = _context.SuperHeroes;
            
            DataSourceResult result = data.ToDataSourceResult(request);
            return Json(result);
        }
        // GET: SuperHeroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superHero = await _context.SuperHeroes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superHero == null)
            {
                return NotFound();
            }

            return View(superHero);
        }

        // GET: SuperHeroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperHeroes/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Poder,Debilidad,Enemigo")] SuperHero superHero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superHero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superHero);
        }

        // GET: SuperHeroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero == null)
            {
                return NotFound();
            }
            return View(superHero);
        }

        // POST: SuperHeroes/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Poder,Debilidad,Enemigo")] SuperHero superHero)
        {
            if (id != superHero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superHero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperHeroExists(superHero.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(superHero);
        }

        // GET: SuperHeroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superHero = await _context.SuperHeroes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superHero == null)
            {
                return NotFound();
            }

            return View(superHero);
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero != null)
            {
                _context.SuperHeroes.Remove(superHero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperHeroExists(int id)
        {
            return _context.SuperHeroes.Any(e => e.Id == id);
        }
    }
}
