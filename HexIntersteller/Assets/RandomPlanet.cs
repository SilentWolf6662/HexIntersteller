using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlanet : MonoBehaviour
{
    [SerializeField] private Material[] Planets;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = new Vector3(Random.Range(-0.025f, 0.025f),0, Random.Range(-0.025f, 0.025f));
        gameObject.GetComponent<MeshRenderer>().material = Planets[Random.Range(0, Planets.Length)];
        transform.rotation = Random.rotation;
        transform.position += offset;
    }
}
