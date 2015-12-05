using Infotainment.Data.Common.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class RssServiceTest
    {
        [TestMethod]
        public void RssService()
        {
            var result = RssProviderService.Instance.GetTopNewsHeader();
        }
    }
}
