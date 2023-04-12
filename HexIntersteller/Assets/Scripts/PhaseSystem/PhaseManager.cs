using UnityEngine;

namespace HexInterstellar.PhaseSystem
{
    public class PhaseManager : MonoBehaviour
    {
        [SerializeField] private PlayerTurn playerTurn;
        [SerializeField] private ResourceSystem.Resources p1Resources, p2Resources;
    }
}
