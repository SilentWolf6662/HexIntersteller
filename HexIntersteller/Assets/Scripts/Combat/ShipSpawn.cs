using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace HexInterstellar
{
    public class ShipSpawn : MonoBehaviour
    {
        [SerializeField] private LayerMask stationLayer;
        [SerializeField] private List<GameObject> ships = new(3);
        [SerializeField] private InputActionReference OpenMenu;
        [SerializeField] private GameObject Station = null;
        private RaycastHit raycastHit = new RaycastHit();
        private Ray ray;
        [SerializeField] private GameObject button;
        bool overStation;
        // Start is called before the first frame update
        void Start()
        {
            OpenMenu.action.Enable();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, stationLayer)) 
            {
                overStation = true;
            }
            else 
                overStation = false;
            if (overStation && OpenMenu.action.ReadValue<float>() > 0 && raycastHit.transform.gameObject.tag == "Station")
            {
                button.SetActive(true);
                Station = raycastHit.transform.gameObject;
            }
            else if (!overStation && OpenMenu.action.ReadValue<float>() > 0 && !EventSystem.current.IsPointerOverGameObject())
            {
                button.SetActive(false);
            }
        }
        public void SpawnShip()
        {
            int index = Random.Range(0, 3);
            GameObject gm = Station.transform.parent.gameObject.GetComponent<BuildingSystem.GetAround>().around[0];
            Vector3 offset = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            Quaternion rot = Quaternion.Euler(new Vector3(0, Random.rotation.y, 0));
            Instantiate(ships[index], gm.transform.position+offset, rot, gm.transform.Find("Ships"));
        }
    }
}
