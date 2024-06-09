using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Entry
{
    public int Id { get; set; }
    public string? Book { get; set; }
    public string? Note { get; set; }
    [Display(Name = "Date Added")]
    [DataType(DataType.Date)]
    public DateTime dateAdded { get; set; }



}