using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class GenreValidation : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        string genre = value.ToString();
        if(genre == "puzzle" || genre == "sandbox" || genre == "strategy")
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
