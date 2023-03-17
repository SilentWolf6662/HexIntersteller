using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAndSides : MonoBehaviour
{
    [SerializeField] private GameObject cityPoint;
    [SerializeField] private GameObject lanePoint;
    [SerializeField] private GameObject pointParent;
    [SerializeField] private GameObject sideParent;
    List<Vector3> points = new List<Vector3>()
    {
        new Vector3(0,0,0.5f),
        new Vector3(0,0,-0.5f),
        new Vector3(0.4329883f,0,0.25f),
        new Vector3(0.4329883f,0,-0.25f),
        new Vector3(-0.4329883f,0,0.25f),
        new Vector3(-0.4329883f,0,-0.25f)

    };
    List<Vector3> sides = new List<Vector3>()
    {
        new Vector3(0.2164941f,0,0.375f),
        new Vector3(0.2164941f,0,-0.375f),
        new Vector3(-0.2164941f,0,0.375f),
        new Vector3(-0.2164941f,0,-0.375f),
        new Vector3(0.4329882f,0,0),
        new Vector3(-0.4329882f,0,0)

    };
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            AddPoints(transform.GetChild(i).gameObject);
            Addsides(transform.GetChild(i).gameObject);
        }
        CheckDoubble(pointParent);
        CheckDoubble(sideParent);
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
            Instantiate(cityPoint, child.transform.position + points[i], pointParent.transform.rotation, pointParent.transform);
        }
    }
    public void Addsides(GameObject child)
    {
        for (int i = 0; i < sides.Count; i++)
        {
            Instantiate(lanePoint, child.transform.position + sides[i], sideParent.transform.rotation, sideParent.transform);
        }
    }
    public void CheckDoubble(GameObject Check)
    {
        for (int i = 0; i < Check.transform.childCount; i++)
        {
            Transform childI = Check.transform.GetChild(i);
            for (int j = i + 1; j < Check.transform.childCount; j++)
            {
                Transform childJ = Check.transform.GetChild(j);
                if (childI.position == childJ.position)
                    Destroy(childJ.gameObject);

            }
        }
    }
}
