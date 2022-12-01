using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IBKSCompany.DATA;
using IBKSCompany.DATA.Models;

namespace IBKSCompany.Views
{
    public class DetailsModel : PageModel
    {
        private readonly IBKSCompany.DATA.AppDbContext _context;

        public DetailsModel(IBKSCompany.DATA.AppDbContext context)
        {
            _context = context;
        }

      public Branch Branch { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Branch == null)
            {
                return NotFound();
            }

            var branch = await _context.Branch.FirstOrDefaultAsync(m => m.BranchID == id);
            if (branch == null)
            {
                return NotFound();
            }
            else 
            {
                Branch = branch;
            }
            return Page();
        }
    }
}
