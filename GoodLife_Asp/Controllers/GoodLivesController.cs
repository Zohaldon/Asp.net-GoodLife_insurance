using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodLife_Asp.Models;
using GoodLife_Asp.Repository;

namespace GoodLife_Asp.Controllers
{
    public class GoodLivesController : Controller
    {
        private readonly AppDbContext _context;

        public GoodLivesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GoodLives
        public async Task<IActionResult> Index()
        {
            return View(await _context.GoodLife.ToListAsync());
        }

        // GET: GoodLives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodLife = await _context.GoodLife
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (goodLife == null)
            {
                return NotFound();
            }

            return View(goodLife);
        }

        // GET: GoodLives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoodLives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,MembershipCost,MembershipDate,Description")] GoodLife goodLife)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodLife);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodLife);
        }

        // GET: GoodLives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodLife = await _context.GoodLife.FindAsync(id);
            if (goodLife == null)
            {
                return NotFound();
            }
            return View(goodLife);
        }

        // POST: GoodLives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,MembershipCost,MembershipDate,Description")] GoodLife goodLife)
        {
            if (id != goodLife.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodLife);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodLifeExists(goodLife.CustomerId))
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
            return View(goodLife);
        }

        // GET: GoodLives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodLife = await _context.GoodLife
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (goodLife == null)
            {
                return NotFound();
            }

            return View(goodLife);
        }

        // POST: GoodLives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goodLife = await _context.GoodLife.FindAsync(id);
            _context.GoodLife.Remove(goodLife);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodLifeExists(int id)
        {
            return _context.GoodLife.Any(e => e.CustomerId == id);
        }
    }
}
