using System;

namespace ServiceOS
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int UomId { get; set; }
    }

    public class ProductMovements
    {
        public int Id { get; set; }

        public DateTime InsertDateTime { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }

    public class ProductUom
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
