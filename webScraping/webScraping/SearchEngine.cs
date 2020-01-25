using System.Threading.Tasks;

namespace webScraping
{
    public abstract class SearchEngine
    {
        public abstract Task<int> GetResult(string input);

    }
}
