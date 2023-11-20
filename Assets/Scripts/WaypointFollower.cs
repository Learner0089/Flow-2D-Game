using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject [] waypoints;//Create waypoint element in unity to modify directly
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position,transform.position)<0.1f)
        //calculate distance between vectors and transform the platform position
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    transform.position = Vector2.MoveTowards(transform.position,waypoints[currentWaypointIndex].transform.position,Time.deltaTime*speed);
    //How many game units we want to move so used Time.deltaTime*speed
    }
}
