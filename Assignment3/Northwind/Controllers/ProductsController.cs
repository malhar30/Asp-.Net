using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;
using System.Net.Http; 
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Northwind.Controllers;

public class ProductsController : Controller
{
    private readonly string baseUrl;
    private readonly string appJson;
    public ProductsController(IConfiguration config)
    {
        baseUrl = config.GetValue<string>("BaseUrl");
        appJson = config.GetValue<string>("AppJson");
    }
    // GET: ProductsController
    [AllowAnonymous]
    public async Task<ActionResult> Index(int categoryId)
    {

       
        try
        {
            if (categoryId == 0)
            {
                categoryId = 1;
            }
            var productData = new List<Product>();
            var categoryList = await GetCategoriesAsync();

            var Category = from n in categoryList
                           select new { CategoryName = n.categoryName, n.categoryId };
            ViewBag.CategoryListData = new SelectList(Category, "categoryId", "CategoryName");
            
            
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                var response = await client.GetAsync($"products/ByCategory/{categoryId}");
                
                
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    productData = JsonSerializer.Deserialize<List<Product>>(json);
                }
               
                else
                {
                    ViewBag.ErrorMessage = response.StatusCode.ToString();
                    return View("Error", new ErrorViewModel());
                }
            }

            return View(productData);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
            return View("Error", new ErrorViewModel());
        }
    }

    [Authorize]
    // GET: ProductsController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var product = await GetProductsAsync(id);
        

        if (product.productId == 0)
        {
            ViewBag.ErrorMessage = $"Product id {id} not found";
            return View("Error", new ErrorViewModel());
        }

        return View(product);
    }

    private async Task<List<Category>> GetCategoriesAsync()
    {
        var category = new List<Category>();

        try
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                var response = await client.GetAsync("categories");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    category = JsonSerializer.Deserialize<List<Category>>(json);
                }
            }
        }
        catch
        {
            
        }

        return category;
    }

    private async Task<Product> GetProductsAsync(int id)
    {
        var productDetails = new Product();

        try
        {
            using (var client = new HttpClient())
            {
                ConfigClient(client);
                var response = await client.GetAsync($"products/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    productDetails = JsonSerializer.Deserialize<Product>(json);
                }
            }
        }
        catch
        {
        }

        return productDetails;
    }
    private void ConfigClient(HttpClient client)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(appJson));
        client.BaseAddress = new Uri(baseUrl);
    }
}
