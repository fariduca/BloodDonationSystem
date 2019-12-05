using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blood_Donation_System.Data;
using Blood_Donation_System.Models;

namespace Blood_Donation_System.Controllers
{
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Donations.Include(d => d.Donor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donations = await _context.Donations
                .Include(d => d.Donor)
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donations == null)
            {
                return NotFound();
            }

            return View(donations);
        }

        // GET: Donations/Create
        public IActionResult Create()
        {
            ViewData["CurrentDonorId"] = new SelectList(_context.Donors, "DonorId", "DonorId");
            ViewBag.today = DateTime.Today.ToString("yyyy-MM-dd");
            ViewBag.earlyDonationWarning = false;
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonationId,DonationCity,Amount,DonatonDate,CurrentDonorId")] Donations donations)
        {           
            if (ModelState.IsValid)
            {
                string latestDonation = _context.Donations.Where(m => m.CurrentDonorId == donations.CurrentDonorId).Max(m => m.DonatonDate);
                DateTime dateTimeD = Convert.ToDateTime(latestDonation);

                if((Convert.ToDateTime(donations.DonatonDate) - dateTimeD).Days < 30)
                {
                    ViewBag.earlyDonationWarning = true;
                    ViewBag.lastD = latestDonation;
                }
                else
                {
                    _context.Add(donations);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }             
            }
            ViewData["CurrentDonorId"] = new SelectList(_context.Donors, "DonorId", "DonorId", donations.CurrentDonorId);
            return View(donations);
        }

        // GET: Donations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donations = await _context.Donations.FindAsync(id);
            if (donations == null)
            {
                return NotFound();
            }
            ViewData["CurrentDonorId"] = new SelectList(_context.Donors, "DonorId", "DonorId", donations.CurrentDonorId);
            return View(donations);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonationId,DonationCity,Amount,DonatonDate,CurrentDonorId")] Donations donations)
        {
            if (id != donations.DonationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationsExists(donations.DonationId))
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
            ViewData["CurrentDonorId"] = new SelectList(_context.Donors, "DonorId", "DonorId", donations.CurrentDonorId);
            return View(donations);
        }

        // GET: Donations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donations = await _context.Donations
                .Include(d => d.Donor)
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donations == null)
            {
                return NotFound();
            }

            return View(donations);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donations = await _context.Donations.FindAsync(id);
            _context.Donations.Remove(donations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonationsExists(int id)
        {
            return _context.Donations.Any(e => e.DonationId == id);
        }
    }
}
