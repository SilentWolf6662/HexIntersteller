using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexInterstellar.BuildingSystem;
using UnityEngine.InputSystem;

namespace HexInterstellar.Combat
{ 
    public class MoveShips : MonoBehaviour
    {
        [SerializeField] private InputActionReference mouseLeftClick;
        [SerializeField] private LayerMask hexagon;
        private RaycastHit raycastHit = new RaycastHit();
        private Ray ray;
        private GameObject startHex;
        private List<GameObject> hexiAround;
        // Start is called before the first frame update
        void Start()
        {
            mouseLeftClick.action.Enable();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit,1000,hexagon) && mouseLeftClick.action.ReadValue<float>() > 0)
            {
                if (startHex == null)
                {
                    startHex = raycastHit.transform.gameObject;
                    startHex.TryGetComponent(out GetSorounding getHexi);
                    if (getHexi != null)
                    {
                        hexiAround = getHexi.GetHexi();
                    }
                }
                else if(startHex != null)
                {

                }
                
            }
        }
    }
}
