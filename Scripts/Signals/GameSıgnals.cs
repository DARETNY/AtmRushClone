using System;
using AtmRushClone.Scripts.Enums;
using AtmRushClone.Scripts.Keys;

namespace AtmRushClone.Scripts.Signals
{
    public static class GameSıgnals
    {
        public sealed record LevelSystemSıgnals
        {
            public static Action<int> OnLevelLoaded = delegate { };
            public static Func<short> OnGetlevelID;
            public static Action OnRestartLevel = delegate { };
            public static Action OnNextLevel = delegate { };
            public static Action OnClearLevel = delegate { };
        }

        public sealed record CoreSignals
        {
            public static Action<Gamestate> OngameState = delegate { };
        }

        public record InputSystemStateSıgnals
        {
            public static Action Onreset = delegate { };
            public static Action Onplay = delegate { };
            public static Action<bool> OninputStateChange = delegate { };
        }

        public record InputSystemSıgnals
        {
            public static Action<HorizantalParms> OninputDraged = delegate { };
            public static Action OnfirstTouch = delegate { };
            public static Action OnTouchrelease = delegate { };
            public static Action InputTaken = delegate { };
        }
    }
}