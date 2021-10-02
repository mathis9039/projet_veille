using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Police : MonoBehaviour
{
    public NavMeshAgent police;
    public Transform Player;
    void Update()
    {
        police.SetDestination(Player.position);
    }
}
