namespace HelloWorldWebApp.Controllers
{
    public interface IWeatherControllerSettings
    {
        double Longitude { set; get; }
        double Latitude { set; get; }
        string ApiKey { set; get; }
    }
}