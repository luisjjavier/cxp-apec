using ApecAxP.Data;
using ApecAxP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApecCxP.Controllers
{
    public class PaymentConceptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentConceptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaymentConcepts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaymentConcepts.ToListAsync());
        }

        // GET: PaymentConcepts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentConcept = await _context.PaymentConcepts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentConcept == null)
            {
                return NotFound();
            }

            return View(paymentConcept);
        }

        // GET: PaymentConcepts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentConcepts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,State")] PaymentConcept paymentConcept)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentConcept);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentConcept);
        }

        // GET: PaymentConcepts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentConcept = await _context.PaymentConcepts.FindAsync(id);
            if (paymentConcept == null)
            {
                return NotFound();
            }
            return View(paymentConcept);
        }

        // POST: PaymentConcepts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,State")] PaymentConcept paymentConcept)
        {
            if (id != paymentConcept.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentConcept);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentConceptExists(paymentConcept.Id))
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
            return View(paymentConcept);
        }

        // GET: PaymentConcepts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentConcept = await _context.PaymentConcepts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentConcept == null)
            {
                return NotFound();
            }

            return View(paymentConcept);
        }

        // POST: PaymentConcepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentConcept = await _context.PaymentConcepts.FindAsync(id);
            _context.PaymentConcepts.Remove(paymentConcept);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentConceptExists(int id)
        {
            return _context.PaymentConcepts.Any(e => e.Id == id);
        }
    }
}
