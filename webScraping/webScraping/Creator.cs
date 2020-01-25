using System;
namespace webScraping
{
    public class Creator
    {
        public const int YAHOO = 1;
        public const int BIND = 2;
        public static SearchEngine CreatorSearchEngine(int tipo)
        {
            switch (tipo)
            {
                case YAHOO: return new Yahoo();
                case BIND: return new Bind();
                default: return null;
            }
        }
    }
}
