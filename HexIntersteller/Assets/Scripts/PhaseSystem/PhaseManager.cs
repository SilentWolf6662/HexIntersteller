using UnityEngine;

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
        public void GiveResources(GameObject building, ResourceSystem.Resources resources)
        {
            for (int i = 0; i < building.transform.childCount; i++)
            {
                building.transform.GetChild(i).gameObject.GetComponent<BuildingSystem.GetAround>().GiveResourses(resources);
            }
        }

    }
}
