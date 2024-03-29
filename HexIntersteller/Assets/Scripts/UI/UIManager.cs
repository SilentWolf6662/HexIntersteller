using UnityEngine;

namespace HexInterstellar.UI
{
	public class UIManager : MonoBehaviour
	{
		[SerializeField] private GameObject buildingMenu, resourceHUD;
		public void ToggleBuildingMenu() => buildingMenu.SetActive(!buildingMenu.activeSelf);
		public void ToggleResourceHUD() => resourceHUD.SetActive(!resourceHUD.activeSelf);
	}
}
