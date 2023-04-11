using HexInterstellar.ResourceSystem;
using UnityEngine;
using UnityEngine.UI;

namespace HexInterstellar.BuildingSystem
{
    public class CostToBuild : MonoBehaviour
    {
        private Button button;
        [SerializeField] private GameObject toSpawn;
        private int[] price;
        private Materials[] mat;
        [SerializeField] private ResourceSystem.Resources resources;
        private void Start()
        {
            button = GetComponent<Button>();
            PriceForBuilding pfb = toSpawn.GetComponent<PriceForBuilding>();
            mat = pfb.materials;
            price = pfb.price;
            CheckBalance();
        }
        public void CheckBalance()
        {
            for (int i = 0; i < price.Length; i++)
            {
                int amount = resources.GetAmount(mat[i].ToString());
                if (amount < price[i])
                {
                    button.interactable = false;
                    Debug.Log(resources.GetAmount(mat[i].ToString()) + "   " + mat[i].ToString());
                    return;
                }
            }
            button.interactable = true;
        }
    }

}