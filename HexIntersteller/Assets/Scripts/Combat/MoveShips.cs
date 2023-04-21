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
        private RaycastHit hit = new RaycastHit();
        private Ray ray;
        private GameObject startHex = null;
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
            if (Physics.Raycast(ray, out hit,1000,hexagon) && mouseLeftClick.action.ReadValue<float>() > 0)
            {
                if (startHex == null)
                {
                    GetStartHex();
                    
                }
                else if(startHex != null)
                {
                    MoveTo();
                    
                }
                
            }
        }
        private void GetStartHex()
        {
            startHex = hit.transform.gameObject;
            if (startHex.transform.parent.Find("Ships").childCount == 0)
            {
                startHex = null;
                return;
            }
            Debug.Log("StartHex Got");
            startHex.transform.parent.gameObject.TryGetComponent(out GetSorounding getHexi);
            if (getHexi != null)
            {
                Debug.Log("Get Hexi");
                hexiAround = getHexi.GetHexi();
            }
        }
        private void MoveTo()
        {
            GameObject obj = hit.transform.gameObject;
            if (obj == startHex)
                return;
            Debug.Log("Move To");
            for (int i = 0; i < hexiAround.Count; i++)
            {
                if (obj.transform.parent.gameObject == hexiAround[i])
                {
                    Debug.Log("Found Hexi OBJ");
                    GameObject ships = startHex.transform.parent.Find("Ships").gameObject;
                    for (int j = ships.transform.childCount-1; j >= 0; j--)
                    {
                        GameObject indvShip = ships.transform.GetChild(j).gameObject;
                        Transform newParent = obj.transform.parent.Find("Ships");
                        indvShip.transform.SetParent(newParent);
                        indvShip.transform.position = newParent.position + new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(0, 0.25f), Random.Range(-0.25f, 0.25f));
                    }
                }
            }
            startHex = null;
        }
    }
}
