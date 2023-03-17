using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAndSides : MonoBehaviour
{
    [SerializeField] private GameObject cityPoint;
    [SerializeField] private GameObject tileMap;
    List<Vector3> points = new List<Vector3>()
        {
            new Vector3(0,0,0.5f),
            new Vector3(0,0,-0.5f),
            new Vector3(0.4329883f,0,0.25f),
            new Vector3(0.4329883f,0,-0.25f),
            new Vector3(-0.4329883f,0,0.25f),
            new Vector3(-0.4329883f,0,-0.25f)

        };
    private void Start()
    {
        for (int i = 0; i < tileMap.transform.childCount; i++)
        {
            AddPoints(tileMap.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childI = transform.GetChild(i);
            for (int j = i+1; j < transform.childCount; j++)
            {
                Transform childJ = transform.GetChild(j);
                if (childI.position == childJ.position)
                    Destroy(childJ.gameObject);

            }
        }
    }
    public void AddPoints(GameObject child)
    {
        //bool samePlace = false;
        for (int i = 0; i < points.Count; i++)
        {
            /*for (int j = 0; j < transform.childCount; j++)
            {
                if(transform.GetChild(j).transform.position == child.transform.position + points[i])
                {
                    samePlace = true;
                }
            }*/
            Instantiate(cityPoint, child.transform.position + points[i], transform.rotation, transform);
        }
    }
}
