using HexInterstellar.PhaseSystem;
using System;
using UnityEngine;

namespace HexInterstellar
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private GameObject stationPrefab, cityPrefab, lanePrefab;
        [SerializeField] private MeshRenderer[] station, city, lane;
        [SerializeField] private Material[] cityMaterials;
        [SerializeField] private Material[] trueMetalMaterials;
        [SerializeField] private Material[] metalMaterials;
        [SerializeField] private Material[] frameMetalMaterials;
        private void Start()
        {
            station[0] = stationPrefab.transform.GetChild(0).GetComponent<MeshRenderer>(); 
            station[1] = stationPrefab.transform.GetChild(1).GetComponent<MeshRenderer>();
            city[0] = cityPrefab.transform.GetChild(0).GetComponent<MeshRenderer>();
            city[1] = cityPrefab.transform.GetChild(1).GetComponent<MeshRenderer>();
            lane[0] = lanePrefab.transform.GetChild(0).GetComponent<MeshRenderer>();
        }
        public void ChangePlayerColor(GameObject pendingObject, PlayerTurn playerTurn)
        {
            if (pendingObject == null) return;
            switch (pendingObject.name)
            {
                case "Lane(Clone)":
                    ChangeMaterial(playerTurn, lane);
                    break;
                case "City(Clone)":
                    ChangeMaterial(playerTurn, city);
                    break;
                case "Station(Clone)":
                    ChangeMaterial(playerTurn, station);
                    break;
                default:

                    break;
            }
        }

        private void ChangeMaterial(PlayerTurn playerTurn, Array array)
        {
            foreach (MeshRenderer meshRendere in array)
            {
                for (int j = 0; j < meshRendere.materials.Length; j++)
                {
                    Material material = meshRendere.materials[j];
                    switch (material.name)
                    {
                        case "City":
                            if (playerTurn == PlayerTurn.P1)
                                material = cityMaterials[1];
                            if (playerTurn == PlayerTurn.P2)
                                material = cityMaterials[2];
                            break;
                        case "TrueMetal":
                            if (playerTurn == PlayerTurn.P1)
                                material = trueMetalMaterials[1];
                            if (playerTurn == PlayerTurn.P2)
                                material = trueMetalMaterials[2];
                            break;
                        case "Metal":
                            if (playerTurn == PlayerTurn.P1)
                                material = metalMaterials[1];
                            if (playerTurn == PlayerTurn.P2)
                                material = metalMaterials[2];
                            break;
                        case "FrameMetal":
                            if (playerTurn == PlayerTurn.P1)
                                material = frameMetalMaterials[1];
                            if (playerTurn == PlayerTurn.P2)
                                material = frameMetalMaterials[2];
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
