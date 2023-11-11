using AtmRushClone.Scripts.Manager;
using UnityEngine;

namespace AtmRushClone.Scripts.Commonds
{
    public class LevelDestroyer
    {
        private readonly LevelManager _levelManager;

        public LevelDestroyer(LevelManager levelManager)
        {
            this._levelManager = levelManager;
        }

        public void Apply()
        {
            Object.Destroy(_levelManager.levelHolder.GetChild(0).gameObject);
        }
    }
}