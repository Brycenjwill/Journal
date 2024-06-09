using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace MyScriptureJournal.Data
{
    public class MyScriptureJournalContext : DbContext
    {
        public MyScriptureJournalContext (DbContextOptions<MyScriptureJournalContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Entry> Entry { get; set; } = default!;
    }
}
