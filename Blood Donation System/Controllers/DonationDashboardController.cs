using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blood_Donation_System.Data;
using Blood_Donation_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blood_Donation_System.Controllers
{
    public class DonationDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationDashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //TODO: Retrieve blood groups and amounts from DB then put in table
            //List<string> bloodGroups = _context.Donations.Select(c => c.Donor.BloodGroup).Distinct().ToList();
            //_context.Donations.Where(c => c.Donor.BloodGroup == bloodGroups[0]).Select(c => c.Amount);

            var bloodBank = _context.Donations.GroupBy(e => e.Donor.BloodGroup).Select(a => new { Amount = a.Sum(b => b.Amount), BloodGroup = a.Key });
            ViewBag.bloodBank = await bloodBank.ToListAsync();

            return View();
        }
    }
}