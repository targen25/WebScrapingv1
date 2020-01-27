using System;
namespace webScraping
{
    public class Creator
    {
        public const int YAHOO = 1;
        public const int BING = 2;
        public static SearchEngine CreatorSearchEngine(int tipo)
        {
            switch (tipo)
            {
                case YAHOO: return new Yahoo();
                case BING: return new Bing();
                default: return null;
            }
        }
    }
}
