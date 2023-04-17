using UnityEngine;

namespace HexInterstellar.PhaseSystem
{
    public class PhaseManager : MonoBehaviour
    {
        [SerializeField] public PlayerTurn playerTurn;
        [SerializeField] private ResourceSystem.Resources p1Resources, p2Resources;
        [SerializeField] private PhaseState phaseState;
        private void Start()
        {
            if (Random.Range(0, 2) == 1)
                playerTurn = PlayerTurn.P1;
            else
                playerTurn = PlayerTurn.P2;
            phaseState = PhaseState.StartPhase;
        }
        public void EndTurn()
        {
            if (playerTurn == PlayerTurn.P2)
            {

                playerTurn = PlayerTurn.P1;
            }
            else
            {

                playerTurn = PlayerTurn.P2;
            }

        }


    }
}
