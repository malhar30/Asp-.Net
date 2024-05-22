using System.ComponentModel.DataAnnotations;

namespace Northwind.Models;


public class Product
{
    [Key]
    public int productId { get; set; }
    [Display(Name ="Name")]
    public string productName { get; set; }
    [Display(Name ="Supplier Id")]
    public int? supplierId { get; set; }
    [Display(Name = "Category Id")]
    public int? categoryId { get; set; }
    [Display(Name = "Quantity Per Unit")]
    public string quantityPerUnit { get; set; }
    [Display(Name = "Unit Price")]
    public decimal unitPrice { get; set; }
    [Display(Name = "In Stock")]
    public int unitsInStock { get; set; }
    [Display(Name = "On Order")]
    public int unitsOnOrder { get; set; }
    [Display(Name = "Reorder Level")]
    public int reorderLevel { get; set; }
    [Display(Name = "DisContinued")]
    public bool discontinued { get; set; }
    public object category { get; set; }
}

