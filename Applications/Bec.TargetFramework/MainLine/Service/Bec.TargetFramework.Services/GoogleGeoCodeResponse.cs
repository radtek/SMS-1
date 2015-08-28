namespace Bec.TargetFramework.Services
{
    public class GoogleGeoCodeResponse
    {
        public string status { get; set; }

        public results[] results { get; set; }
    }
}