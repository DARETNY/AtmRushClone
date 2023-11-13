using System;
using AtmRushClone.Scripts.Base;
using AtmRushClone.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AtmRushClone.Scripts.Controller.UI
{
    public class ShopPanelController : MonoBehaviour,IPanelhandler
    {
        [SerializeField] private TextMeshProUGUI money, ıncomeValue, ıncomeLevelText;
        [SerializeField] private Button incomeLvlbutton, stackValueButton;
        private int _getmoney;
        public UIpanelType currentIpanelType; // to check correct panel aint neccesary
        private IPanelhandler _panelhandler;
        
       

        private void Start()
        {
            if (GetIpanelType()!=currentIpanelType)
            {
                throw new Exception("Not valid Panel");
            }
            incomeLvlbutton.onClick.AddListener(Call);
        }

        private void Call()
        {
            money.SetText($"curent balance {_getmoney++}");
        }

        public UIpanelType GetIpanelType()
        {
            return UIpanelType.Shop;
        }
    }
}