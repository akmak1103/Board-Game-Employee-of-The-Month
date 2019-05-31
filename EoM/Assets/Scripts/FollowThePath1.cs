using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath1 : MonoBehaviour {

    public Transform[] waypoints;

    private float moveSpeed = 5f;

    public int waypointIndex = 0;

    //public Dice numberOfSteps;

	private void Start ()                   // Use this for initialization
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }
	
	
	
	// Update is called once per frame

	private void Update ()
    {
            Move();
	}


    private void Move()
    {
        if (waypointIndex <= 41)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
