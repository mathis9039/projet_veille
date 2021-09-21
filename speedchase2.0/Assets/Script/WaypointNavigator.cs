using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    NPCNavController controller;
    public Waypoint currentWaypoint;

    private void Awake(){
        controller = GetComponent<NPCNavController>();
    }
    void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());

    }

    // Update is called once per frame
    void Update()
    {
        if(controller.reachedDestination){
            currentWaypoint = currentWaypoint.nextWaypoint;
            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
