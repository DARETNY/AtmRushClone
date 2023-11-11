using System;

namespace AtmRushClone.Scripts.Signals
{
    public static class GameSıgnals
    {
        public sealed class LevelSystemSıgnals
        {
            public static Action<int> OnLevelLoaded = delegate { };
            public static Func<short> OnGetlevelID;
            public static Action OnRestartLevel = delegate { };
            public static Action OnNextLevel = delegate { };
            public static Action OnClearLevel = delegate { };
        }
    }
}