using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class Game
{
    [Key]
    public int GameId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Developer { get; set; }
    [Required]
    [GenreValidation(ErrorMessage = "Please select from sandbox, strategy, and puzzle.")]
    public string Genre { get; set; }
    [Required]
    [Display(Name ="Release Year")]
    [ReleaseYearValidation(ErrorMessage ="Error")]
    public int ReleaseYear { get; set; }
    [DataType(DataType.Date), Display(Name = "Purchase Date")]
    [DateSeenValidation(ErrorMessage = "Date can't be in future.")]
    public DateTime? PurchaseDate { get; set; }
    [Range(1, 100)]
    public int Rating { get; set; }
}
