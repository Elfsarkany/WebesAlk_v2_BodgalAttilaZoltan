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
    public class DetailsModel : PageModel
    {
        private readonly WebesAlk_v2_BodgalAttilaZoltan.Data.ApplicationDbContext _context;

        public DetailsModel(WebesAlk_v2_BodgalAttilaZoltan.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Character Character { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }
            else 
            {
                Character = character;
            }
            return Page();
        }
    }
}
