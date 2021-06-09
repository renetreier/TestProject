using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestProject
{
    public class TransportData:PageModel
    {
        public List<string> VehicleNumberList = new();
        protected char TransportIndex;

        protected void GetDataFromWebsite(string url, List<string> dataList)
        {
            ClearLists(dataList);
            var myClient = new WebClient();
            Stream response = myClient.OpenRead(url);
            WriteToList(response, dataList);
            response.Close();
        }
        protected void WriteToList(Stream response,List<string> dataList)
        {
            using StreamReader sr = new(response);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line[0] == TransportIndex)
                {
                    string cleanLine=CleanUpString(line);
                    dataList.Add(cleanLine);
                }
            }
            dataList.Sort();
        }
        protected string CleanUpString(string s)
        {
            string[] l=s.Split(',');
            string cleanString = "";
            if (!VehicleNumberList.Contains(l[1]))
                VehicleNumberList.Add(l[1]);
            cleanString += $"{l[1]},{l[3].Substring(0,2)}.{l[3].Substring(2)}N," +
                           $"{l[2].Substring(0, 2)}.{l[2].Substring(2)}E";
            return cleanString;
        }
        public List<string> VehicleNumbers = new();
        public List<string> VehicleCoordinates = new();
        public List<string> DistinctVehicleNumberList = new();
        public void GetVehicleData(List<string> vehicles)
        {
            foreach (string v in vehicles)
            {
                string vNumber = v.Substring(0, v.IndexOf(','));
                VehicleNumbers.Add(vNumber);
                VehicleCoordinates.Add(v.Substring(v.IndexOf(',') + 1));
                AddDistinctVehicles(vNumber);
            }
        }
        public void GetVehicleData(List<string> vehicles, string VN)
        {
            foreach (string v in vehicles)
            {
                string vNumber = v.Substring(0, v.IndexOf(','));
                if (vNumber.ToLower().Contains(VN.ToLower()))
                {
                    VehicleNumbers.Add(vNumber);
                    VehicleCoordinates.Add(v.Substring(v.IndexOf(',') + 1));
                }
                AddDistinctVehicles(vNumber);
            }
        }
        public void ClearLists(List<string> dl )
        {
            VehicleNumberList.Clear();
            VehicleNumbers.Clear();
            VehicleCoordinates.Clear();
            DistinctVehicleNumberList.Clear();
            dl.Clear();
        }
        public void AddDistinctVehicles(string vNumber)
        {
            if (!DistinctVehicleNumberList.Contains(vNumber))
                DistinctVehicleNumberList.Add(vNumber);
        }
    }
}
