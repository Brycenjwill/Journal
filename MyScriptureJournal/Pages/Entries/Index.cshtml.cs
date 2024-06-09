using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using RazorPagesMovie.Models;

namespace MyScriptureJournal.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchNotes { get; set; }
        public string? SearchBooks { get; set;  }

        public SelectList? Books { get; set; }
        public SelectList? Dates { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? EntryBook { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? EntryDate { get; set; }

        public async Task OnGetAsync()
        {
    IQueryable<string> bookQuery = from m in _context.Entry
                                    orderby m.Book
                                    select m.Book;

    IQueryable<DateTime> dateQuery = from m in _context.Entry
                                    orderby m.dateAdded    
                                    select m.dateAdded;

            var entries = from m in _context.Entry
                 select m;

    if (!string.IsNullOrEmpty(SearchNotes))
    {
        entries = entries.Where(s => s.Note.Contains(SearchNotes));
    }
    if (!string.IsNullOrEmpty(SearchBooks))
    {
        entries = entries.Where(s => s.Book.Contains(SearchBooks));
    }

     if (EntryDate.HasValue)
    {
                entries = entries.Where(x => x.dateAdded == EntryDate);
    }

            if (!string.IsNullOrEmpty(EntryBook))
    {
        entries = entries.Where(x => x.Book == EntryBook);
    }
    Dates = new SelectList(await dateQuery.Distinct().ToListAsync());
    Books = new SelectList(await bookQuery.Distinct().ToListAsync());
    Entry = await entries.ToListAsync();
        }
    }
}
