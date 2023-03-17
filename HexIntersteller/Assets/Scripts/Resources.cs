using System;
using TMPro;
using UnityEngine;

namespace HexInterstellar.Resources
{
	public class Resources : MonoBehaviour 
	{
		[SerializeField] private TMP_Text creditText, planarText, metalText, rationText;
		private int creditAmount, planarAmount, metalAmount, rationAmount;

		private void Start()
		{
			creditAmount = 0;
			planarAmount = 0;
			metalAmount = 0;
			rationAmount = 0;
		}

		public int GetAmount(string resourceType)
		{
			switch (resourceType)
			{
				case "ration":
					return rationAmount;
				case "metal":
					return metalAmount;
				case "planar":
					return planarAmount;
				case "credit":
					return creditAmount;
			}
			return 0;
		}
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
