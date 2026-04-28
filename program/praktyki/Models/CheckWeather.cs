namespace praktyki.Models
{
    public class WeatherResponse
    {

        public Current current { get; set; }
    }

    public class Current
    {
        public double temp_c { get; set; }
        public Condition condition { get; set; }
    }

    public class Condition
    {
        public string text { get; set; }
        public string icon { get; set; }
    }
}