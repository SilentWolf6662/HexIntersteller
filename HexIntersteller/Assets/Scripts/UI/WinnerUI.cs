using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HexInterstellar
{
    public class WinnerUI : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
            if (WinCondition.winner != 0)
            {
                text.text = $"The Winner Is Player {WinCondition.winner}";
            }
            else
            {
                text.text = "There is no Winner yet";
            }
        }
    }
}
