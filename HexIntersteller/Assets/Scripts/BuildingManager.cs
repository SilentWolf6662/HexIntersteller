using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private InputActionReference PlaceBuild;

    public GameObject[] objects;
    private GameObject pendingObject;

    private Vector3 pos;

    private RaycastHit hit;

    [SerializeField] private LayerMask[] layerMasks;

    private int indexSelected = 0;

    private void Start()
    {
        PlaceBuild.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(pendingObject != null)
        {
            pendingObject.transform.position = pos;

            if (PlaceBuild.action.ReadValue<float>()>0)
            {
                PlaceObject();
            }
        }
    }

    public void PlaceObject()
    {
        pendingObject = null;
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*10);
        if (Physics.Raycast(ray, out hit, 1000, layerMasks[indexSelected]) && pendingObject != null)
        {
            pos = hit.point;
        }
    }

    public void SelectedObject(int index)
    {
        pendingObject = Instantiate(objects[index], pos, transform.rotation);
        indexSelected = index;
    }
}
