using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HexInterstellar.Resources
{
    public class CostToBuild : MonoBehaviour
    {
        private Button button;
        [SerializeField] private int[] price;
        [SerializeField] private Materials[] mat;
        [SerializeField] private Resources resources;
 
        public void CheckBalance()
        {
            for (int i = 0; i < price.Length; i++)
            {
                int amount = resources.GetAmount(mat[i].ToString());
                if (amount < price[i])
                {
                    button.interactable = false;
                    return;
                }
            }
            button.interactable = true;
        }
    }

}