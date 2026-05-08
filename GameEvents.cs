using System;
using System.Collections.Generic;
using System.Text;

namespace NodeStrategy
{
    public static class GameEvents
    {
        public static event Action<int, int> OnGoldAdd;

        public static void TriggerGoldGeneration(int factionId, int goldAmount)
        {
            OnGoldAdd?.Invoke(factionId, goldAmount);
        }
    }
}
