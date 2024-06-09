using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using RazorPagesMovie.Models;

namespace MyScriptureJournal.Models;


public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MyScriptureJournalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MyScriptureJournalContext>>()))
        {
            if (context == null || context.Entry == null)
            {
                throw new ArgumentNullException("Null RazorPagesEntryContext");
            }

            // Look for any Entrys.
            if (context.Entry.Any())
            {
                return;   // DB has been seeded
            }

            context.Entry.AddRange(
                new Entry
                {
                    Book = "Mormon",
                    dateAdded = DateTime.Parse("1989-2-12"),
                    Note = "The is a good book"
                }
            );
            context.SaveChanges();
        }
    }
}
