namespace Blazor_server_app.Data.GeoLocation
{
    public class PositionOptions
    {
        public bool EnableHighAccuracy { get; set; } = false;
        public int Timeout { get; set; }
        public int MaximumAge { get; set; } = 0;
    }
}
