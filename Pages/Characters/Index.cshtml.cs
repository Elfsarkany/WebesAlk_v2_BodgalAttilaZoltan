using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebesAlk_v2_BodgalAttilaZoltan.Data;
using WebesAlk_v2_BodgalAttilaZoltan.Models;

namespace WebesAlk_v2_BodgalAttilaZoltan.Pages.Characters
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly WebesAlk_v2_BodgalAttilaZoltan.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(WebesAlk_v2_BodgalAttilaZoltan.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Character> Character { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (_context.Characters != null)
            {
                Character = await _context.Characters.Where(data => data.UserId == user.Id).ToListAsync();
            }
        }
    }
}
