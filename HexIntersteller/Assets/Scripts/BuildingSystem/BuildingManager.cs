using HexInterstellar.PhaseSystem;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
namespace HexInterstellar.BuildingSystem
{
    public class BuildingManager : MonoBehaviour
    {
        [SerializeField] private InputActionReference PlaceBuild;

        public GameObject[] objects;
        private GameObject pendingObject;

        public GameObject habitatP1;
        public GameObject stationP1;
        public GameObject hyperlaneP1;
        public GameObject habitatP2;
        public GameObject stationP2;
        public GameObject hyperlaneP2;

        private Vector3 pos;

        private Quaternion rot;

        private RaycastHit hit;

        [SerializeField] private LayerMask[] layerMasks;

        private Ray ray;

        [SerializeField] private ResourceSystem.Resources resources;

        private PriceForBuilding price;

        public GameObject p1Building;
        public GameObject p2Building;

        private PhaseSystem.PhaseManager phaseManager;
        private PhaseSystem.PlayerTurn P1 = PhaseSystem.PlayerTurn.P1;
        private PhaseSystem.PlayerTurn P2 = PhaseSystem.PlayerTurn.P2;

        private void Start()
        {
            phaseManager = GameObject.Find("PhaseManager").GetComponent<PhaseSystem.PhaseManager>();
            PlaceBuild.action.Enable();
        }
        // Update is called once per frame
        private void Update()
        {
            if (pendingObject != null)
            {
                pendingObject.transform.position = pos;
                pendingObject.transform.rotation = rot;
                

                if (PlaceBuild.action.ReadValue<float>() > 0 && !EventSystem.current.IsPointerOverGameObject())
                {
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
            if (phaseManager.playerTurn == P1)
            {
                pendingObject.transform.SetParent(p1Building.transform);
            }
            else if (phaseManager.playerTurn == P2)
            {
                pendingObject.transform.SetParent(p2Building.transform);
            }
            GetAround runFind;
            pendingObject.TryGetComponent<GetAround>(out runFind);
            if(runFind != null)
                runFind.FindAround();
            Destroy(hit.transform.gameObject);
            pendingObject = null;
        }
        private void FixedUpdate()
        {

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10);
            if (pendingObject == null) return;
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
            ReplaceToPlayerObject();
        }
        private void ReplaceToPlayerObject()
        {
            var test = phaseManager.playerTurn;
            if (test == PlayerTurn.P1)
            {
                if (pendingObject.name == "Habitat(Clone)")
                    pendingObject = ReplaceObject(pendingObject, habitatP1, pos, transform.rotation);
                else if (pendingObject.name == "Hyperlane(Clone)")
                    pendingObject = ReplaceObject(pendingObject, hyperlaneP1, pos, transform.rotation);
                else if (pendingObject.name == "Station(Clone)")
                    pendingObject = ReplaceObject(pendingObject, stationP1, pos, transform.rotation);
            }
            else if (test == PlayerTurn.P2)
            {
                if (pendingObject.name == "Habitat(Clone)")
                    pendingObject = ReplaceObject(pendingObject, habitatP2, pos, transform.rotation);
                else if (pendingObject.name == "Hyperlane(Clone)")
                    pendingObject = ReplaceObject(pendingObject, hyperlaneP2, pos, transform.rotation);
                else if (pendingObject.name == "Station(Clone)")
                    pendingObject = ReplaceObject(pendingObject, stationP2, pos, transform.rotation);
            }
        }

        public GameObject ReplaceObject(GameObject defaultObject, GameObject playerObject, Vector3 position, Quaternion rotation)
        {
            GameObject replacedObject = Instantiate(playerObject, position, rotation);
            Destroy(defaultObject);
            return replacedObject;
        }

    }
}
