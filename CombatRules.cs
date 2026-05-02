using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public static class CombatRules
    {
        public static float ExpPerDefeatedUnit = 0.01f;
        public static float CombatLethality { get;} = 0.15f;
        public static float ExpWeight { get; } = 0.5f;

    }
}
