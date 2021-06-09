using System;
using System.Collections.Generic;

namespace TestProject.Pages
{
    public class TramsModel : TransportData
    {
        public List<string> Trams = new();
        public void OnGet()
        {
            TransportIndex = '3';
            GetDataFromWebsite("https://transport.tallinn.ee/gps.txt", Trams);
            GetVehicleData(Trams);
        }

        public void OnPost()
        {
            TransportIndex = '3';
            var Vehicle = Request.Form["vehicle"];
            GetDataFromWebsite("https://transport.tallinn.ee/gps.txt", Trams);
            GetVehicleData(Trams,Vehicle);
        }

    }
}
