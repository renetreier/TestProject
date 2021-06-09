using System.Collections.Generic;

namespace TestProject.Pages
{
    public class BusesModel : TransportData
    {
        public List<string> Buses = new();
        public string BusNumber;
        public void OnGet()
        {
            TransportIndex = '2';
            GetDataFromWebsite("https://transport.tallinn.ee/gps.txt", Buses);
            GetVehicleData(Buses);
        }

        public void OnPost()
        {
            TransportIndex = '2';
            var Vehicle = Request.Form["vehicle"];
            GetDataFromWebsite("https://transport.tallinn.ee/gps.txt", Buses);
            GetVehicleData(Buses, Vehicle);
        }
    }
}
