using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
namespace HexInterstellar.Resources
{
    public class BuildingManager : MonoBehaviour
    {
        [SerializeField] private InputActionReference PlaceBuild;

        public GameObject[] objects;
        private GameObject pendingObject;

        private Vector3 pos;

        private Quaternion rot;

        private RaycastHit hit;

        [SerializeField] private LayerMask[] layerMasks;

        Ray ray;

        [SerializeField] private Resources resources;

        PriceForBuilding price;

        private void Start()
        {
            PlaceBuild.action.Enable();
        }

        // Update is called once per frame
        void Update()
        {
            if (pendingObject != null)
            {
                pendingObject.transform.position = pos;
                pendingObject.transform.rotation = rot;
                

                if (PlaceBuild.action.ReadValue<float>() > 0 && !EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("GOT HERE");
                    PlaceObject();
                }
            }
        }

        public void PlaceObject()
        {
            price = pendingObject.GetComponent<PriceForBuilding>();
            for (int i = 0; i < price.price.Length; i++)
            {
                resources.RemoveAmount(price.price[i], price.materials[i].ToString());
            }
            pendingObject = null;
        }

        private void FixedUpdate()
        {

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10);
            if (pendingObject != null)
                if (Physics.Raycast(ray, out hit, 1000, pendingObject.GetComponent<LayerPlacement>().placedOn))
                {
                    pos = hit.transform.position;
                    rot = hit.transform.rotation;
                }
        }

        public void SelectedObject(GameObject gm)
        {
            Destroy(pendingObject);
            pendingObject = Instantiate(gm, pos, transform.rotation);
        }
    }
}
