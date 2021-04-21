using System.Text.Json.Serialization;

namespace ReportEntities
{
    public class Sensor
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    public class FuelSensor : Sensor { }
    public class IgnitionSensor : Sensor { }
    public class SnockSensor : Sensor { }
}
