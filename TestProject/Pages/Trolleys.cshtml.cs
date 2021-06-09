using System.Collections.Generic;

namespace TestProject.Pages
{
    public class TrolleysModel : TransportData
    {
        public List<string> Trolleys = new();

        public void OnGet()
        {
            TransportIndex = '1';
            GetDataFromWebsite("https://transport.tallinn.ee/gps.txt", Trolleys);
            GetVehicleData(Trolleys);
        }
        public void OnPost()
        {
            TransportIndex = '1';
            var Vehicle = Request.Form["vehicle"];
            GetDataFromWebsite("https://transport.tallinn.ee/gps.txt", Trolleys);
            GetVehicleData(Trolleys, Vehicle);
        }
    }
}
