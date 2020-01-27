using System.Threading.Tasks;

namespace webScraping
{
    public abstract class SearchEngine
    {
        public abstract Task<long> GetResult(string input);

    }
}
