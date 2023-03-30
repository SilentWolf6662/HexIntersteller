using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexInterstellar.Resources
{
    public class CostToBuild : MonoBehaviour
    {
        [SerializeField] private int[] price;
        [SerializeField] private Materials[] mat;
        [SerializeField] private Resources resources;
 
        public void CheckBalance()
        {
            for (int i = 0; i < price.Length; i++)
            {
                
            }
        }
    }

}