using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IBKSCompany.DATA;
using IBKSCompany.DATA.Models;

namespace IBKSCompany.Views
{
    public class EditModel : PageModel
    {
        private readonly IBKSCompany.DATA.AppDbContext _context;

        public EditModel(IBKSCompany.DATA.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Branch Branch { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Branch == null)
            {
                return NotFound();
            }

            var branch =  await _context.Branch.FirstOrDefaultAsync(m => m.BranchID == id);
            if (branch == null)
            {
                return NotFound();
            }
            Branch = branch;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Branch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(Branch.BranchID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BranchExists(int id)
        {
          return _context.Branch.Any(e => e.BranchID == id);
        }
    }
}
