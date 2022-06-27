using MaraphonSkills.Core.ModelAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MaraphonSkills.Core.API
{
    public class CharityAPI
    {
        WebClient client = new WebClient();
        public static List<Charity> GetCharityList()
        {
            //var client = new WebClient();
            //return JsonObject.Deserialize<List<Charity>>(client.DownloadString($"{Manager.RootUrl}/charityunformatted"));

            var client = new WebClient();

            // Получение данных из json 
            return JsonObject.Deserialize<Response<List<Charity>>>(client.DownloadString($"{Manager.RootUrl}/charity")).data;
        }
    }
}
