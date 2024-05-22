using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class ReleaseYearValidation : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        int releaseYear = (int)value;
        return releaseYear <= (int)DateTime.Now.Year -3;

    }
}
