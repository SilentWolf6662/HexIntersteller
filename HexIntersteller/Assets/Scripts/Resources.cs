using TMPro;
using UnityEngine;

namespace HexInterstellar.Resources
{
	public class Resources : MonoBehaviour 
	{
		[SerializeField] private TMP_Text creditText, planarText, metalText, rationText;
		[SerializeField] private CostToBuild costToBuild;
		private int creditAmount, planarAmount, metalAmount, rationAmount;

		private void Start() => creditAmount = planarAmount = metalAmount = rationAmount = 0;

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
			costToBuild.CheckBalance();
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
			costToBuild.CheckBalance();
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
			costToBuild.CheckBalance();
		}
		public void UpdateUI()
		{
			metalText.text = $"{metalAmount}x";
			rationText.text = $"{rationAmount}x";
			planarText.text = $"{planarAmount}x";
			creditText.text = $"{creditAmount}x";
		}
	}
}
