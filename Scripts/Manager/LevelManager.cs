using System;
using AtmRushClone.Scripts.Commonds;
using AtmRushClone.Scripts.Data;
using AtmRushClone.Scripts.Signals;
using UnityEngine;

namespace AtmRushClone.Scripts.Manager
{
    public class LevelManager : MonoBehaviour
    {
        public LevelData levelData;
        public Transform levelHolder;
        private LevelLoader _levelLoader;
        private LevelDestroyer _levelDestroyer;

        private void Awake()
        {
            _levelLoader = new LevelLoader(this);
            _levelDestroyer = new LevelDestroyer(this);
        }

        private void Start()
        {
            GameSıgnals.LevelSystemSıgnals.OnLevelLoaded?.Invoke(levelData.level);
            Debug.Log(GetLevelID());
        }

        private void OnEnable()
        {
            Subscribe();
        }

        //*-------------*
        void Subscribe()
        {
            GameSıgnals.LevelSystemSıgnals.OnGetlevelID += GetLevelID;
            GameSıgnals.LevelSystemSıgnals.OnNextLevel += DonextLevel;
            GameSıgnals.LevelSystemSıgnals.OnRestartLevel += RestartLevel;
            GameSıgnals.LevelSystemSıgnals.OnLevelLoaded += _levelLoader.Load;
            GameSıgnals.LevelSystemSıgnals.OnClearLevel += _levelDestroyer.Apply;
        }

        void Unsubscribe()
        {
            GameSıgnals.LevelSystemSıgnals.OnGetlevelID -= GetLevelID;
            GameSıgnals.LevelSystemSıgnals.OnNextLevel -= DonextLevel;
            GameSıgnals.LevelSystemSıgnals.OnRestartLevel -= RestartLevel;
            GameSıgnals.LevelSystemSıgnals.OnLevelLoaded -= _levelLoader.Load;
            GameSıgnals.LevelSystemSıgnals.OnClearLevel -= _levelDestroyer.Apply;
        }

        //*-------------*

        private void OnDisable()
        {
            Unsubscribe();
        }

        private short GetLevelID()
        {
            return (short)(levelData.level % levelData.totallevel);
        }

        private void DonextLevel()
        {
            levelData.level++;
        }

        private void RestartLevel()
        {
            //todo: restart level
        }
    }
}