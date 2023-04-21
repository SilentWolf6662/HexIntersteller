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
			UpdateUI();
			UpdateBal();
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
			if (metalAmount <= 0) metalAmount = 0;
			if (rationAmount <= 0) rationAmount = 0;
			if (planarAmount <= 0) planarAmount = 0;
			if (creditAmount <= 0) creditAmount = 0;
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
