using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class PassPlays
    {
        public static Dictionary<String, OffensivePlay> GetIFormTwoWRPassPlays()
        {
            Dictionary<String, OffensivePlay> retVal = new Dictionary<string, OffensivePlay>();
            RouteTypes[] routes = new RouteTypes[] { RouteTypes.SLANT, RouteTypes.OUT, RouteTypes.GO, RouteTypes.PASS_BLOCK, RouteTypes.DRAG };
            OffensivePlay play = new OffensivePlay(OffensivePlayType.PASS, null, routes);
            retVal.Add("Deep Pass", play);
            return retVal;
        }
    }
}
