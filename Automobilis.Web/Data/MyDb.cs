using Automobilis.Web.Models;
using System.Text.Json;

namespace Automobilis.Web.Data;

public static class MyDb
{
    public static List<Brand> GetBrands()
    {
        var brands = JsonSerializer.Deserialize<List<Brand>>(File.ReadAllText(@"C:\Users\anton\projetos-locais\Automobilis\Automobilis\Automobilis.Web\wwwroot\car_brands.json"));
        return brands;
    }
}

