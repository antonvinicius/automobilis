﻿using System.Text.Json.Serialization;

namespace Automobilis.Domain.Entities
{
    public class Brand
    {
        public Brand(string name, string picture)
        {
            Name = name;
            Picture = picture;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        [JsonIgnore]
        public ICollection<Car>? Cars { get; set; }
    }
}
