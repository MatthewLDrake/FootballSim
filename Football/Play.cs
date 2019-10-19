using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football
{
    public class Play
    {
        private Formation formation;
        public Play(Formation formation)
        {
            this.formation = formation;
        }
        public Formation GetFormation()
        {
            return formation;
        }
    }
    public class OffensivePlay : Play
    {
        private OffensivePlayType type;
        private Formation formation;
        private Player[] eligibleReceivers;
        private RouteTypes[] routes;
        public OffensivePlay(OffensivePlayType type, Formation formation) : base(formation)
        {
            this.type = type;
            this.formation = formation;
        }

        public OffensivePlay(OffensivePlayType type, Formation formation, RouteTypes[] routes) : base(formation)
        {
            if (type != OffensivePlayType.PASS)
            {
                return;
            }
            this.type = type;
            this.routes = routes;
            this.formation = formation;
        }
        public OffensivePlayType GetType()
        {
            return type;
        }
        
    }
    public class DefensivePlay : Play
    {
        private DefensivePlayType type;
        public DefensivePlay(DefensivePlayType type, Formation formation) : base(formation)
        {
            this.type = type;
        }
        public DefensivePlayType GetType()
        {
            return type;
        }
    }
}
