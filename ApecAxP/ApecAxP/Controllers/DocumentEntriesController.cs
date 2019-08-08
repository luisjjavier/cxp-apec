using ApecAxP.Data;
using ApecAxP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApecCxP.Controllers
{
    public class DocumentEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DocumentEntries
        public async Task<IActionResult> Index()
        {
            var cxPContext = _context.DocumentEntries.Include(d => d.Provider);
            return View(await cxPContext.ToListAsync());
        }

        // GET: DocumentEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentEntry = await _context.DocumentEntries
                .Include(d => d.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentEntry == null)
            {
                return NotFound();
            }

            return View(documentEntry);
        }

        // GET: DocumentEntries/Create
        public IActionResult Create()
        {
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Id");
            return View();
        }

        // POST: DocumentEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BillNumber,DocumentDate,Amount,RegisterDate,ProviderId")] DocumentEntry documentEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentEntry);
                await _context.SaveChangesAsync();

                AddAccountingSeat(documentEntry);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Id", documentEntry.ProviderId);

            return View(documentEntry);
        }

        private static void AddAccountingSeat(DocumentEntry documentEntry)
        {

            using (HttpClient client = new HttpClient())
            {
                var AccountingSeat = new
                {
                    Id = documentEntry.BillNumber,
                    Cuenta = "Cuenta Corriente BHD",
                    Tipo = "Corriente",
                    Monto = documentEntry.Amount
                };

                string url = "https://sistemacontabilidadintegraciones.azurewebsites.net";
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                string endPoint = "/api/asientocontable";
                HttpContent content = new StringContent(JsonConvert.SerializeObject(AccountingSeat));

                var response = client.PostAsync(endPoint, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error");
                }
            }
        }

        // GET: DocumentEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentEntry = await _context.DocumentEntries.FindAsync(id);
            if (documentEntry == null)
            {
                return NotFound();
            }
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Id", documentEntry.ProviderId);
            return View(documentEntry);
        }

        // POST: DocumentEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BillNumber,DocumentDate,Amount,RegisterDate,ProviderId")] DocumentEntry documentEntry)
        {
            if (id != documentEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentEntryExists(documentEntry.Id))
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
            ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Id", documentEntry.ProviderId);
            return View(documentEntry);
        }

        // GET: DocumentEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentEntry = await _context.DocumentEntries
                .Include(d => d.Provider)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentEntry == null)
            {
                return NotFound();
            }

            return View(documentEntry);
        }

        // POST: DocumentEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentEntry = await _context.DocumentEntries.FindAsync(id);
            _context.DocumentEntries.Remove(documentEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentEntryExists(int id)
        {
            return _context.DocumentEntries.Any(e => e.Id == id);
        }
    }
}
