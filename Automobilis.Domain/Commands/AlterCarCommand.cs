namespace Automobilis.Domain.Commands
{
    public class AlterCarCommand
    {
        public AlterCarCommand()
        {

        }

        public AlterCarCommand(int brandId, string model, int fabYear, int modelYear, double price, string description, string? picture)
        {
            BrandId = brandId;
            Model = model;
            FabYear = fabYear;
            ModelYear = modelYear;
            Price = price;
            Description = description;
            Picture = picture;
        }

        public AlterCarCommand(int carId, int brandId, string model, int fabYear, int modelYear, double price, string description, string? picture)
        {
            CarId = carId;
            BrandId = brandId;
            Model = model;
            FabYear = fabYear;
            ModelYear = modelYear;
            Price = price;
            Description = description;
            Picture = picture;
        }

        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public int FabYear { get; set; }
        public int ModelYear { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string? Picture { get; set; } = "";
    }
}
