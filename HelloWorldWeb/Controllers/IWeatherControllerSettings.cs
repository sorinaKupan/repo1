namespace HelloWorldWebApp.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Longitude { set; get; }
        string Latitude { set; get; }
        string ApiKey { set; get; }
    }
}