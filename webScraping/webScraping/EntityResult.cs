using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webScraping
{
    public class EntityResult
    {

        public async Task<int> GetResultYahoo(string input)
        {
            int result = 0;
            string url = "https://search.yahoo.com/search?p=" + input;
            string keyWord = "Next</a><span>";

            EntityQuantity eQuantity = new EntityQuantity();
            result = await eQuantity.GetQuantity(url, keyWord);
            return result;
        }
        public async Task<int> GetResultBind(string input)
        {
            int result = 0;
            string url = "https://www.bing.com/search?q=" + input;
            string keyWord = "class=\"sb_count\"";
            EntityQuantity eQuantity = new EntityQuantity();
            result = await eQuantity.GetQuantity(url, keyWord);
            return result;
        }

    }
}
