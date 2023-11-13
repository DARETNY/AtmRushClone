using AtmRushClone.Scripts.Enums;
using AtmRushClone.Scripts.Manager.Locater;
using AtmRushClone.Scripts.Signals;
using UnityEngine;

namespace AtmRushClone.Scripts.Manager
{
    public class GameManager : MonoBehaviour, ILocater
    {
        public Gamestate gamestate;
        private void Awake()
        {
            if (Application.isMobilePlatform) Application.targetFrameRate = 60;
            ServiceLocater.Register(this);
        }

        private void OnEnable()
        {
            GameSıgnals.CoreSignals.OngameState += GamestateChange;
        }

        private void OnDisable()
        {
            GameSıgnals.CoreSignals.OngameState -= GamestateChange;
        }

        private void GamestateChange(Gamestate nextstate)
        {
            gamestate = nextstate;
        }
    }
}