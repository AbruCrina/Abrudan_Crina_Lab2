﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abrudan_Crina_Lab2.Data;
using Abrudan_Crina_Lab2.Models;

namespace Abrudan_Crina_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Abrudan_Crina_Lab2.Data.Abrudan_Crina_Lab2Context _context;

        public DetailsModel(Abrudan_Crina_Lab2.Data.Abrudan_Crina_Lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            //var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);

            var borrowing = await _context.Borrowing
            .Where(m => m.ID == id)
            .Include(b => b.Book)
              .ThenInclude(b => b.Author)
            .Include(b => b.Member)

    .FirstOrDefaultAsync();

            if (borrowing == null)
            {
                return NotFound();
            }
            else
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}