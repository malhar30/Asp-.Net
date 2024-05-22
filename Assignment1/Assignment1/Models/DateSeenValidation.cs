﻿using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class DateSeenValidation : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var dateSeen = Convert.ToDateTime(value);
        return dateSeen <= DateTime.Now;
    }
}
