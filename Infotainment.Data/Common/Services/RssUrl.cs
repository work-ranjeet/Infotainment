using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotainment.Data.Common.Services
{
    public class RssUrl
    {
        internal static RssUrl Instance
        {
            get
            {
                return new RssUrl();
            }
        }

        internal static readonly string DanikJagaranTopNews = "http://rss.jagran.com/rss/news/national.xml";
        internal static readonly string NawBharatTimesTopNews = "http://navbharattimes.indiatimes.com/rssfeedstopstories.cms";
        internal static readonly string NawBharatTimesHome = "http://navbharattimes.indiatimes.com/rssfeedsdefault.cms";

        internal static readonly string DanikJagaranInternationalNews = "http://rss.jagran.com/rss/news/world.xml";
        internal static readonly string NawBharatInternationalNews = "http://navbharattimes.indiatimes.com/world/rssfeedsection/2279801.cms";
           
       
        internal IStateRss GetState(string StateCode)
        {
            switch(StateCode)
            {
                case "BR":
                    return new Bihar();
                case "HR":
                    return new Haryana();
                case "HP":
                    return new Himachal();
                case "UP":
                    return new Up();
                case "DL":
                    return new Delhi();
                case "PB":
                    return new Panjab();
                case "JH":
                    return new Jharkhand();
                case "RJ":
                    return new Rajsthan();
                case "MP":
                    return new MadhyaPradesh();
                case "CT":
                    return new Chhatisgarh();
            }

            return null;
        }

        internal interface IStateRss
        {
            IEnumerable<string> DistRssUrl { get; }
        }

        internal class Bihar: IStateRss
        {
            public IEnumerable<string> DistRssUrl
            {
                get
                {
                    return new List<string>()
                    {
                        "http://rss.jagran.com/local/bihar/patna-city.xml",
                        "http://rss.jagran.com/local/bihar/bhagalpur.xml",
                        "http://rss.jagran.com/local/bihar/muzaffarpur.xml",
                        "http://rss.jagran.com/local/bihar/gaya.xml",
                        "http://rss.jagran.com/local/bihar/darbhanga.xml"
                    };
                }
            }
        }

        internal class Up : IStateRss
        {
            public IEnumerable<string> DistRssUrl
            {
                get
                {
                    return new List<string>()
                    {
                        "http://rss.jagran.com/local/uttar-pradesh/kanpur-city.xml",
                        "http://rss.jagran.com/local/uttar-pradesh/lucknow-city.xml",
                        "http://rss.jagran.com/local/uttar-pradesh/agra-city.xml",
                        "http://rss.jagran.com/local/uttar-pradesh/allahabad-city.xml"
                    };
                }
            }
        }

        internal class Panjab : IStateRss
        {
            public IEnumerable<string> DistRssUrl
            {
                get
                {
                    return new List<string>()
                    {
                        "http://rss.jagran.com/local/punjab/chandigarh.xml",
                        "http://rss.jagran.com/local/punjab/jalandhar.xml",
                        "http://rss.jagran.com/local/punjab/ludhiana.xml",
                        "http://rss.jagran.com/local/punjab/amritsar.xml",
                        "http://rss.jagran.com/local/punjab/ropar.xml"
                    };
                }
            }
        }

        internal class Haryana : IStateRss
        {
            public IEnumerable<string> DistRssUrl
            {
                get
                {
                    return new List<string>()
                    {
                        "http://rss.jagran.com/local/punjab/chandigarh.xml",
                        "http://rss.jagran.com/local/punjab/jalandhar.xml",
                        "http://rss.jagran.com/local/punjab/ludhiana.xml",
                        "http://rss.jagran.com/local/punjab/amritsar.xml",
                        "http://rss.jagran.com/local/punjab/ropar.xml"
                    };
                }
            }
        }

        internal class Delhi : IStateRss
        {
            public IEnumerable<string> DistRssUrl
            {
                get
                {
                    return new List<string>()
                    {
                        "http://rss.jagran.com/local/delhi/new-delhi-city.xml"
                    };
                }
            }
        }

        internal class Himachal : IStateRss
        {
            public IEnumerable<string> DistRssUrl
            {
                get
                {
                    return new List<string>()
                    {
                        "http://rss.jagran.com/local/himachal-pradesh/shimla.xml",
                        "http://rss.jagran.com/local/himachal-pradesh/mandi.xml",
                        "http://rss.jagran.com/local/himachal-pradesh/bilaspur-hp.xml",
                        "http://rss.jagran.com/local/himachal-pradesh/una.xml",
                        "http://rss.jagran.com/local/himachal-pradesh/chamba.xml"

                    };
                }
            }
        }

        internal class Jharkhand : IStateRss
        {
            public IEnumerable<string> DistRssUrl
            {
                get
                {
                    return new List<string>()
                    {
                        "http://rss.jagran.com/local/jharkhand/ranchi.xml",
                        "http://rss.jagran.com/local/jharkhand/dhanbad.xml",
                        "http://rss.jagran.com/local/jharkhand/jamshedpur.xml",
                        "http://rss.jagran.com/local/jharkhand/hazaribagh.xml",
                        "http://rss.jagran.com/local/jharkhand/giridih.xml"

                    };
                }
            }
        }

        internal class Rajsthan : IStateRss
        {
            public IEnumerable<string> DistRssUrl
            {
                get
                {
                    return new List<string>()
                    {
                        "http://rss.jagran.com/local/rajasthan/jaipur.xml"
                    };
                }
            }
        }

        internal class MadhyaPradesh : IStateRss
        {
            public IEnumerable<string> DistRssUrl
            {
                get
                {
                    return new List<string>()
                    {
                        "http://rss.jagran.com/local/madhya-pradesh/bhopal.xml"
                    };
                }
            }
        }

        internal class Chhatisgarh : IStateRss
        {
            public IEnumerable<string> DistRssUrl
            {
                get
                {
                    return new List<string>()
                    {
                        "http://rss.jagran.com/local/chhattisgarh/raipur.xml",
                        "http://rss.jagran.com/local/chhattisgarh/bilaspur-chhattisgarh.xml"
                    };
                }
            }
        }

    }

}
