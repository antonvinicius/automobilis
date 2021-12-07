﻿namespace Automobilis.Web.Models;

public class Brand
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Picture { get; set; }

    public ICollection<Car> Cars { get; set; }
}

