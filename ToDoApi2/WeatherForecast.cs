namespace ToDoApi2
{
    public class WeatherForecast
    {
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public DateOnly Date { get; set; }

        
        public string? Summary { get; set; }
    }
}
