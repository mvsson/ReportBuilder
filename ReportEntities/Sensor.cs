namespace ReportEntities
{
    public abstract class Sensor
    {
        public string Name { get; set; }
    }
    public class FuelSensor : Sensor { }
    public class IgnitionSensor : Sensor { }
    public class SnockSensor : Sensor { }
}
