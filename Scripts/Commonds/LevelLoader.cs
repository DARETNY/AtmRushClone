using AtmRushClone.Scripts.Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace AtmRushClone.Scripts.Commonds
{
    public class LevelLoader
    {
        private readonly LevelManager _levelManager;

        public LevelLoader(LevelManager levelManager)
        {
            this._levelManager = levelManager;
        }

        public void Load(int level)
        {
            var resourceRequest = Resources.LoadAsync<GameObject>($"Prefabs/Levels/Level {level}");
            resourceRequest.completed += (obj) =>
            {
                var spawnedobject =
                    Object.Instantiate(resourceRequest.asset.GameObject(), Vector3.zero, Quaternion.identity);
                if (spawnedobject != null) spawnedobject.transform.SetParent(_levelManager.levelHolder);
            };
        }
    }
}