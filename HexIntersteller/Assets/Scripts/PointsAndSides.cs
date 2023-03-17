using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAndSides : MonoBehaviour
{
    [SerializeField] private GameObject cityPoint;
    [SerializeField] private GameObject tileMap;
    private void Start()
    {
        
        List<Vector3> points = new List<Vector3>()
        {
            new Vector3(0,0,0.5f),
            new Vector3(0,0,-0.5f),
            new Vector3(0.4329883f,0,0.25f),
            new Vector3(0.4329883f,0,-0.25f),
            new Vector3(-0.4329883f,0,0.25f),
            new Vector3(-0.4329883f,0,-0.25f)

        };
        AddPoints(points);
    }
    public void AddPoints(List<Vector3> points)
    {
        bool samePlace = false;
        for (int i = 0; i < points.Count; i++)
        {
            for (int j = 0; j < transform.childCount; j++)
            {
                if(transform.GetChild(j).transform.position == transform.position + points[i])
                {
                    samePlace = true;
                }
            }
            if(!samePlace)
                Instantiate(cityPoint, transform.position + points[i], transform.rotation, transform);
        }
    }
}
