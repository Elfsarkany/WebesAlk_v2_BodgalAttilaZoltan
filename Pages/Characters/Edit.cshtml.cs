using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebesAlk_v2_BodgalAttilaZoltan.Data;
using WebesAlk_v2_BodgalAttilaZoltan.Models;

namespace WebesAlk_v2_BodgalAttilaZoltan.Pages.Characters
{
    public class EditModel : PageModel
    {
        private readonly WebesAlk_v2_BodgalAttilaZoltan.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(WebesAlk_v2_BodgalAttilaZoltan.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Character Character { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            var character =  await _context.Characters.FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }
            Character = character;
            var user = await _userManager.GetUserAsync(User);
            Character.UserId = user.Id;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Character.UserId");
            var user = await _userManager.GetUserAsync(User);
            Character.UserId = user.Id;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(Character.Id))
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

        private bool CharacterExists(int id)
        {
          return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
