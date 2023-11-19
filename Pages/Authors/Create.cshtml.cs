using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Abrudan_Crina_Lab2.Data;
using Abrudan_Crina_Lab2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Abrudan_Crina_Lab2.Pages.Authors
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Abrudan_Crina_Lab2.Data.Abrudan_Crina_Lab2Context _context;

        public CreateModel(Abrudan_Crina_Lab2.Data.Abrudan_Crina_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Author == null || Author == null)
            {
                return Page();
            }

            _context.Author.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
