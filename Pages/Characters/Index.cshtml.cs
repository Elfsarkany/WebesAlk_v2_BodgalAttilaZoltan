using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebesAlk_v2_BodgalAttilaZoltan.Data;
using WebesAlk_v2_BodgalAttilaZoltan.Models;

namespace WebesAlk_v2_BodgalAttilaZoltan.Pages.Characters
{
    public class IndexModel : PageModel
    {
        private readonly WebesAlk_v2_BodgalAttilaZoltan.Data.ApplicationDbContext _context;

        public IndexModel(WebesAlk_v2_BodgalAttilaZoltan.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Character> Character { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Characters != null)
            {
                Character = await _context.Characters.ToListAsync();
            }
        }
    }
}
