using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // using array to keep multiple waypoints
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1;
    [SerializeField] float acceptableErrorMargin = .1f;

    void Update()
    {   // change the index if that's the case
        if (Vector3.Distance(transform.position, this.waypoints[this.currentWaypointIndex].transform.position) < this.acceptableErrorMargin)
        {
            this.currentWaypointIndex++;
            // when it reaches the left waypoint => index is incremented to 1. when it reaches the right one the index = 2
            // if index 2 => index goes back to 0 => left
            if (this.currentWaypointIndex >= this.waypoints.Length)
            {
                this.currentWaypointIndex = 0;
            }
            
        }
        // transform here refers to the transform component in the object which contains this script
            transform.position = Vector3.MoveTowards(
                transform.position,
                this.waypoints[this.currentWaypointIndex].transform.position,
                this.speed * Time.deltaTime
                );

    }
}
