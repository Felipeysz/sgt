using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGT.Data;
using SGT.Models;


namespace SGT.Controllers
{
    public class PontoController : Controller
    {
        private readonly SGTContext _context;

        public PontoController(SGTContext context)
        {
            _context = context;
        }

        // GET: Ponto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pontos.ToListAsync());
        }

        // GET: Ponto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponto = await _context.Pontos
                .FirstOrDefaultAsync(m => m.id == id);
            if (ponto == null)
            {
                return NotFound();
            }

            return View(ponto);
        }

        // GET: Ponto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ponto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nome,Latitude,Longitude")] Ponto ponto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ponto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ponto);
        }

        // GET: Ponto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponto = await _context.Pontos.FindAsync(id);
            if (ponto == null)
            {
                return NotFound();
            }
            return View(ponto);
        }

        // POST: Ponto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nome,Latitude,Longitude")] Ponto ponto)
        {
            if (id != ponto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ponto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoExists(ponto.id))
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
            return View(ponto);
        }

        // GET: Ponto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponto = await _context.Pontos
                .FirstOrDefaultAsync(m => m.id == id);
            if (ponto == null)
            {
                return NotFound();
            }

            return View(ponto);
        }

        // POST: Ponto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ponto = await _context.Pontos.FindAsync(id);
            _context.Pontos.Remove(ponto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoExists(int id)
        {
            return _context.Pontos.Any(e => e.id == id);
        }
    }
}
