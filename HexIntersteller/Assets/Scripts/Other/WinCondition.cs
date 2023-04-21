using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HexInterstellar
{
    public class WinCondition : MonoBehaviour
    {
        [SerializeField] private List<GameObject> allPlanets = new List<GameObject>();
        public static int winner = 0;
        [SerializeField] private bool win = false;
        void Update()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                List<GameObject> list = transform.GetChild(i).gameObject.GetComponent<BuildingSystem.GetAround>().around;
                for (int j = 0; j < list.Count; j++)
                {
                    if (!allPlanets.Contains(list[j]))
                    {
                        allPlanets.Add(list[j]);
                    }
                }
            }
            if (allPlanets.Count > 10||win)
            {
                winner = Convert.ToInt32(Convert.ToString(gameObject.name[1]));
                SceneManager.LoadScene(2);
            }
        }
    }
}
