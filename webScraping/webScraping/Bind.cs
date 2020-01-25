using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace webScraping
{
    class Bind : SearchEngine
    {
        public override async Task<int> GetResult(string input)
        {
            int quantity = 0;
            string url = "https://www.bing.com/search?q=" + input;
            string keyWord = "class=\"sb_count\"";

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
