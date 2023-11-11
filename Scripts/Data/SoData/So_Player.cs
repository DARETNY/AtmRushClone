using UnityEngine;

namespace AtmRushClone.Scripts.Data.SoData
{
    [CreateAssetMenu(fileName = "Player", menuName = "Builder/Player", order = 0)]
    public class So_Player : ScriptableObject
    {
        public Inputdata inputdata;
    }
}