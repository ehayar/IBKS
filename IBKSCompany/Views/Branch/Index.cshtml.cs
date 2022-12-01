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
    public class IndexModel : PageModel
    {
        private readonly IBKSCompany.DATA.AppDbContext _context;

        public IndexModel(IBKSCompany.DATA.AppDbContext context)
        {
            _context = context;
        }

        public IList<Branch> Branch { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Branch != null)
            {
                Branch = await _context.Branch.ToListAsync();
            }
        }
    }
}
