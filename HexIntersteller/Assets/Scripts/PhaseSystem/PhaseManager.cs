using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HexInterstellar.PhaseSystem
{
    public class PhaseManager : MonoBehaviour
    {
        [SerializeField] public PlayerTurn playerTurn;
        [SerializeField] private ResourceSystem.Resources p1Resources, p2Resources;
        [SerializeField] private GameObject p1Buildings, p2Buildings;
        [SerializeField] private PhaseState phaseState;
        private void Start()
        {
            if (Random.Range(0, 2) == 1) 
                playerTurn = PlayerTurn.P1;
            else
                playerTurn = PlayerTurn.P2;
            phaseState = PhaseState.StartPhase;
            NextPhase();
        }
        public void NextPhase()
        {
            while (true)
            {
                switch (phaseState)
                {
                    case PhaseState.StartPhase:
                        phaseState = PhaseState.BuildPhase;
                        break;
                    case PhaseState.BuildPhase:
                        phaseState = PhaseState.EndPhase;
                        continue;
                    case PhaseState.EndPhase:
                        EndTurn();
                        phaseState = PhaseState.BuildPhase;
                        break;
                    case PhaseState.StartCombatPhase:
                        break;
                    case PhaseState.CombatPhase:
                        break;
                    case PhaseState.AttackPhase:
                        break;
                    case PhaseState.DefendPhase:
                        break;
                    case PhaseState.EndCombatPhase:
                        break;
                    default:
                        Debug.LogError("Not a valid Phase");
                        break;
                }
                break;
            }
        }
        public void EndTurn()
        {
            if (playerTurn == PlayerTurn.P2)
            {
                GiveResources(p2Buildings, p2Resources);
                playerTurn = PlayerTurn.P1;
            }
            else
            {
                GiveResources(p1Buildings, p1Resources);
                playerTurn = PlayerTurn.P2;
            }
        }
        public static void GiveResources(GameObject building, ResourceSystem.Resources resources)
        {
            for (int i = 0; i < building.transform.childCount; i++)
            {
                building.transform.GetChild(i).gameObject.GetComponent<BuildingSystem.GetAround>().GiveResourses(resources);
            }
        }
    }
}
