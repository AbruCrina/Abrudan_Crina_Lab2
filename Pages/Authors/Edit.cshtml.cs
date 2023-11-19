using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Abrudan_Crina_Lab2.Data;
using Abrudan_Crina_Lab2.Models;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Authorization;

namespace Abrudan_Crina_Lab2.Pages.Authors
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Abrudan_Crina_Lab2.Data.Abrudan_Crina_Lab2Context _context;

        public EditModel(Abrudan_Crina_Lab2.Data.Abrudan_Crina_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Abrudan_Crina_Lab2.Models.Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var author =  await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }
            Author = author;
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

            _context.Attach(Author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(Author.ID))
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

        private bool AuthorExists(int id)
        {
          return (_context.Author?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
