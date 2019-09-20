using System;
using System.Threading.Tasks;

namespace EmpowermentApp
{
    public class Core
    {
        public static async Task<Empowerment> GetEmpowerment(string zipCode)
        {
            //Sign up for a free API key at http://openEmpowermentmap.org/appid
            string key = "c1a891cded2235c742621b2308755e15";
            string queryString = "http://api.openEmpowermentmap.org/data/2.5/Empowerment?zip="
                + zipCode + ",us&appid=" + key + "&units=imperial";

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["Empowerment"] != null)
            {
                Empowerment Empowerment = new Empowerment();
                Empowerment.Title = (string)results["name"];
                Empowerment.Temperature = (string)results["main"]["temp"] + " F";
                Empowerment.Wind = (string)results["wind"]["speed"] + " mph";
                Empowerment.Humidity = (string)results["main"]["humidity"] + " %";
                Empowerment.Visibility = (string)results["Empowerment"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                Empowerment.Sunrise = sunrise.ToString() + " UTC";
                Empowerment.Sunset = sunset.ToString() + " UTC";
                return Empowerment;
            }
            else
            {
                return null;
            }
        }
    }
}