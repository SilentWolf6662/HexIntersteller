using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HexInterstellar
{
    public class ShipSpawn : MonoBehaviour
    {
        [SerializeField] private InputActionReference OpenMenu;
        private RaycastHit raycast;
        private Ray ray;
        // Start is called before the first frame update
        void Start()
        {
            OpenMenu.action.Enable();
        }

        // Update is called once per frame
        void Update()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out raycast, 1000, gameObject.layer);
            if(raycast.transform.gameObject == gameObject && OpenMenu.action.ReadValue<float>() > 0)
            {

            }

        }
    }
}
