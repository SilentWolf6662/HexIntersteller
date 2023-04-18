using HexInterstellar.BuildingSystem;
using TMPro;
using UnityEngine;

namespace HexInterstellar.ResourceSystem
{
	public class Resources : MonoBehaviour 
	{
		[SerializeField] private TMP_Text creditText, planarText, metalText, rationText;
		[SerializeField] private CostToBuild[] costToBuild;
		private int creditAmount, planarAmount, metalAmount, rationAmount;

		private void Start()
		{
			creditAmount = planarAmount = metalAmount = rationAmount = 10;
			//Debug.Log($"{creditAmount}, {planarAmount}, {metalAmount}, {rationAmount}");
		}

		public int GetAmount(string resourceType) => resourceType switch { "ration" => rationAmount, "metal" => metalAmount, "planar" => planarAmount, "credit" => creditAmount, _ => 0 };
		public void AddAmount(int number, string resourceType)
		{
			switch (resourceType)
			{
				case "ration":
					rationAmount += number;
					break;
				case "metal":
					metalAmount += number;
					break;
				case "planar":
					planarAmount += number;
					break;
				case "credit":
					creditAmount += number;
					break;
			}
			UpdateBal();
		}
		public void RemoveAmount(int number, string resourceType)
		{
			switch (resourceType)
			{
				case "ration":
					rationAmount -= number;
					break;
				case "metal":
					metalAmount -= number;
					break;
				case "planar":
					planarAmount -= number;
					break;
				case "credit":
					creditAmount -= number;
					break;
			}
			UpdateBal();
		}
		public void SetAmount(int number, string resourceType)
		{
			switch (resourceType)
			{
				case "ration":
					rationAmount = number;
					break;
				case "metal":
					metalAmount = number;
					break;
				case "planar":
					planarAmount = number;
					break;
				case "credit":
					creditAmount = number;
					break;
			}
			UpdateBal();
		}
		public void UpdateUI()
		{
			metalText.text = $"{metalAmount}x";
			rationText.text = $"{rationAmount}x";
			planarText.text = $"{planarAmount}x";
			creditText.text = $"{creditAmount}x";
		}
        public void UpdateBal()
        {
            for (int i = 0; i < costToBuild.Length; i++)
            {
				costToBuild[i].CheckBalance();
            }
        }
    }
}
