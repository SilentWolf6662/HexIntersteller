using System.Collections.Generic;
using UnityEngine;

namespace HexInterstellar.ResourceSystem
{
    public class ResourceGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject Tilemap;
        private List<GameObject> Hexi;
        private List<int> amountCheck = new List<int>() { 12, 12, 12, 12 };
        [SerializeField] private List<GameObject> Tokens;
        // Start is called before the first frame update
        private void Start()
        {
            Hexi = new List<GameObject>();
            for (int i = 0; i < Tilemap.transform.childCount; i++)
            {
                //Debug.Log(i);
                GameObject tile = Tilemap.transform.GetChild(i).gameObject;
                if (tile.CompareTag("Hex") && tile.name != "Hex Tile Middle")
                    Hexi.Add(tile);
            }
            for (int i = 0; i < Hexi.Count; i++)
            {
                AssignResource(i, 0);
            }
        }

        private void AssignResource(int i, int step)
        {
            int rnd = Random.Range(0, 4);
            if (step > 100)
            {
                Debug.Log("Could Not finish assigning!");
                return;
            }

            if (amountCheck[rnd] > 0)
            {
                amountCheck[rnd]--;
                Instantiate(Tokens[rnd], new Vector3(Hexi[i].transform.position.x + 0.2f, Hexi[i].transform.position.y + 0.018f, Hexi[i].transform.position.z + -0.2f), Quaternion.Euler(-90, -90, 0), Hexi[i].transform);
                return;
            }
            step++;
            AssignResource(i, step);
        }
    }
}
