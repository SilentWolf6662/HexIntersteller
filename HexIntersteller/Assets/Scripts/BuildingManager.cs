using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private InputActionReference PlaceBuild;

    public GameObject[] objects;
    private GameObject pendingObject;

    private Vector3 pos;

    private Quaternion rot;

    private RaycastHit hit;

    [SerializeField] private LayerMask[] layerMasks;

    private int indexSelected = 0;

    Ray ray;

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
            pendingObject.transform.rotation = rot;

            if (PlaceBuild.action.ReadValue<float>()>0 && !EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("GOT HERE");
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
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*10);
        if (Physics.Raycast(ray, out hit, 1000, layerMasks[indexSelected]) && pendingObject != null)
        {
            pos = hit.transform.position;
            rot = hit.transform.rotation;
        }
    }

    public void SelectedObject(int index)
    {
        Destroy(pendingObject);
        pendingObject = Instantiate(objects[index], pos, transform.rotation);
        indexSelected = index;
        Debug.Log(index);
    }
}
