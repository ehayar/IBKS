using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IBKSCompany.DATA;
using IBKSCompany.DATA.Models;

namespace IBKSCompany.Views.Client
{
    public class IndexModel : PageModel
    {
        private readonly IBKSCompany.DATA.AppDbContext _context;

        public IndexModel(IBKSCompany.DATA.AppDbContext context)
        {
            _context = context;
        }

        public IList<IBKSCompany.DATA.Models.Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Client != null)
            {
                Client = await _context.Client.ToListAsync();
            }
        }
    }
}
