using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebesAlk_v2_BodgalAttilaZoltan.Data;
using WebesAlk_v2_BodgalAttilaZoltan.Models;

namespace WebesAlk_v2_BodgalAttilaZoltan.Pages.Characters
{
    public class CreateModel : PageModel
    {
        private readonly WebesAlk_v2_BodgalAttilaZoltan.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(WebesAlk_v2_BodgalAttilaZoltan.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Character Character { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();
            Character.UserId = user.Id;
            ModelState.Remove("Character.User");
            ModelState.Remove("Character.UserId");
            TryValidateModel(Character);
            if (!ModelState.IsValid || _context.Characters == null || Character == null)
            {
                return Page();
            }
            // 406ecd7b-b6b8-4b7c-88d0-5ab6e40a0964
            _context.Characters.Add(Character);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
