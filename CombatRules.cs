using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public static class CombatRules
    {

        public static float combatLethality { get; private set; } = 0.15f;
        public static float expWeight { get; private set; } = 0.5f;

    }
}
