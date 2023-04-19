using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexInterstellar.ResourceSystem;

namespace HexInterstellar.BuildingSystem
{

    public class GetAround : MonoBehaviour
    {
        [SerializeField] private List<GameObject> around = new List<GameObject>();
        [SerializeField] private Dictionary<Materials, int> materials = new Dictionary<Materials, int>() { { Materials.credit, 0 }, { Materials.metal, 0 }, { Materials.planar, 0 }, { Materials.ration, 0 } };
        [SerializeField] private GameObject levelGrid;

        private List<Vector3> points = new List<Vector3>
        {
            new Vector3(0, 0, 0.5f),
            new Vector3(0, 0, -0.5f),
            new Vector3(0.4329883f, 0, 0.25f),
            new Vector3(0.4329883f, 0, -0.25f),
            new Vector3(-0.4329883f, 0, 0.25f),
            new Vector3(-0.4329883f, 0, -0.25f)

        };
        // Start is called before the first frame update
        private void Start()
        {
            levelGrid = GameObject.Find("Tilemap");
        }
        public void FindAround()
        {
            for (int i = 0; i < levelGrid.transform.childCount; i++)
            {
                Transform child = levelGrid.transform.GetChild(i);
                for (int j = 0; j < points.Count; j++)
                {
                    if (child.position == transform.position + points[j])
                    {
                        around.Add(child.gameObject);
                        if (child.childCount != 1)
                        {
                            Debug.Log(child.GetChild(1).name);
                            switch (child.GetChild(1).name)
                            {
                                case "Food(Clone)":
                                    materials[Materials.ration]++;
                                    break;
                                case "Solar(Clone)":
                                    materials[Materials.planar]++;
                                    break;
                                case "Credit(Clone)":
                                    materials[Materials.credit]++;
                                    break;
                                case "Metal(Clone)":
                                    materials[Materials.metal]++;
                                    break;
                                default:

                                    break;
                            }

                        }
                    }
                }
            }
        }
        public void GiveResourses(ResourceSystem.Resources playerRes)
        {
            FindAround();
            Debug.Log("initialized giveresourses");
            foreach  (KeyValuePair<Materials,int> kvp in materials)
            {
                Debug.Log(kvp.Key + "  " + kvp.Value);
                if (kvp.Value != 0)
                {
                    
                    playerRes.AddAmount(kvp.Value, kvp.Key.ToString());
                }
            }
        }
    }
}
