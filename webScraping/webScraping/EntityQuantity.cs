using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace webScraping
{
    public class EntityQuantity
    {
      public async Task<int> GetQuantity(string url, string keyWord)
        {
            int quantity = 0;
            HttpClient httpClient = new HttpClient();
            string html = await httpClient.GetStringAsync(url);

            int start = html.IndexOf(keyWord) + keyWord.Length;
            int end = start + 40;
            string result = html.Substring(start, end - start);

            string onlyNumber = Regex.Replace(result, "[a-zA-Z</>,\n. ]", "");
            quantity = Convert.ToInt32(onlyNumber);
            return quantity;

        }
    }
}
