using System.ComponentModel.DataAnnotations;

namespace Automobilis.Domain.Entities
{
    public class Car
    {
        public Car(int brandId, string model, int fabYear, int modelYear, double price, string description, string? picture)
        {
            BrandId = brandId;
            Model = model;
            FabYear = fabYear;
            ModelYear = modelYear;
            Price = price;
            Description = description;
            Picture = picture;
        }

        public int Id { get; set; }
        public Brand? Brand { get; set; }
        [Required(ErrorMessage = "Marca é obrigatório")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Modelo é obrigatório")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Ano de fabricação é obrigatório")]
        public int FabYear { get; set; }
        [Required(ErrorMessage = "Ano do modelo é obrigatório")]
        public int ModelYear { get; set; }
        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Preço é obrigatório")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatório")]
        public string Description { get; set; }
        public string? Picture { get; set; }
    }
}
