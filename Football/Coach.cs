using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football
{
    class Coach
    {
        private string name;
        private int offenseSkill, defenseSkill, stSkill, developmentSkill;
        // figure out how to implement systems
        public Coach(string name, int offense, int defense, int specialTeams, int developmentSkill)
        {
            this.name = name;
            offenseSkill = offense;
            defenseSkill = defense;
            specialTeams = stSkill;
            this.developmentSkill = developmentSkill;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
