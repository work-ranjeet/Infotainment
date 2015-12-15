using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotainment.Data.Entities.Common
{
    public interface IStateCode
    {
        string Code { get; set; }

        string Name { get; set; }
    }

    public class StateCode : IStateCode
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
