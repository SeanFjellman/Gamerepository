using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }
}
