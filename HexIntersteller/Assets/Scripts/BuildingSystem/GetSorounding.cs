using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexInterstellar
{
    public class GetSorounding : MonoBehaviour
    {
        Dictionary<Vector3Int,GameObject> grid = new Dictionary<Vector3Int,GameObject>();
        List<Vector3> around = new List<Vector3>()
        {
            new Vector3(0.4329883f,0,0.75f),
            new Vector3(-0.4329883f,0,0.75f),
            new Vector3(0.4329883f,0,-0.75f),
            new Vector3(-0.4329883f,0,-0.75f),
            new Vector3(0.8659766f,0,0),
            new Vector3(-0.8659766f,0,0)
        };
        // Start is called before the first frame update
        void Start()
        {
            Transform parent = transform.parent;
            for (int i = 0; i < parent.childCount; i++)
            {
                IsAround(parent.GetChild(i));
            }
            Debug.Log(grid.Count);
            Debug.Log(grid[new Vector3Int(1, 0, 0)].transform.position);
        }
        private void IsAround(Transform child)
        {
            for (int i = 0; i < around.Count; i++)
            {
                if (child.position - transform.position == around[i])
                {
                    if (i == 0)
                        grid.Add(new Vector3Int(1, 0, 0), child.gameObject);
                    if (i == 1)
                        grid.Add(new Vector3Int(0, 0, -1), child.gameObject);
                    if (i == 2)
                        grid.Add(new Vector3Int(0, 0, 1), child.gameObject);
                    if (i == 3)
                        grid.Add(new Vector3Int(-1, 0, 0), child.gameObject);
                    if (i == 4)
                        grid.Add(new Vector3Int(0, 1, 0), child.gameObject);
                    if (i == 5)
                        grid.Add(new Vector3Int(0, -1, 0), child.gameObject);
                }
            }
        }
        /// <summary>
        /// Positive X = top right,
        /// Negative X = bottom left,
        /// Positive Y = right,
        /// Positive Y = left,
        /// Positive Z = bottom right,
        /// Positive Z = top left,
        /// </summary>
        /// <param name="cell">For gettign hexagons around the specified hex, Only one param per call</param>
        public GameObject GetHex(Vector3Int cell)
        {
            if (grid.ContainsKey(cell))
                return grid[cell];
            else
                return null;
        }
        /// <summary>
        /// Return a list of all Hexi around the original Hex
        /// </summary>
        /// <returns></returns>
        public List<GameObject> GetHexi()
        {
            List<GameObject> hexi = new List<GameObject>();
            foreach (KeyValuePair<Vector3Int,GameObject> kvp in grid)
            {
                hexi.Add(kvp.Value);
            }
            return hexi;

        }
    }
}
