using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace webScraping
{
    class Yahoo : SearchEngine
    {
        public override async Task<long> GetResult(string input)
        {
            long quantity = 0;
            string url = "https://search.yahoo.com/search?p=" + input;
            string keyWord = "Next</a><span>";

            HttpClient httpClient = new HttpClient();
            string html = await httpClient.GetStringAsync(url);

            int start = html.IndexOf(keyWord) + keyWord.Length;
            int end = start + 40;
            string result = html.Substring(start, end - start);

            string onlyNumber = Regex.Replace(result, "[a-zA-Z</>,\n. ]", "");
            quantity = Convert.ToInt64(onlyNumber);
            return quantity;

        }
    }
}
