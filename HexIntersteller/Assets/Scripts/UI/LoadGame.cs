using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexInterstellar
{
    public class LoadGame : MonoBehaviour
    {
        public void StartGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}

