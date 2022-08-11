using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//private - Unity cannot, others classes cannot
//public -  Unity can, other claesses can
//[SerializeField] private - Unity can, other classes cannot

public class AIAgent : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _waypoints; //declare
    [SerializeField] private int _waypointindex = 0;
    // Start is called before the first frame update\
    //Array
    //pros: they are fast and simple
    //cons: they cannot be resized
    public bool IsPlayerInRange()
    {
        if (Vector2.Distance(transform.position,
            _player.transform.position) < 5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ChasePlayer()
    {
        MoveToPoint(_player.transform.position);
    }

    public void Patrol()
    {
        Vector2 waypointPosition = _waypoints[_waypointindex].position;

        MoveToPoint(waypointPosition);

        if (Vector2.Distance(transform.position, waypointPosition) < 0.1f)
        {
            _waypointindex++;
        }
        //_waypointIndex = (_waypointIndex+1) % _waypoints.length;
        if (_waypointindex >= _waypoints.Length) //4
        {
            _waypointindex = 0;
        }
    }

    // Update is called once per frame
    void MoveToPoint(Vector2 point)
    {
        // this.transform.position;
        Vector2 directionToPlayer = point - (Vector2)transform.position;

        //if you want to know the direction from A to B
        // A -----> B
        // DirAToB = B - A;
        if (directionToPlayer.magnitude > 0.1f)
        {
            directionToPlayer.Normalize();
            directionToPlayer *= _speed * Time.deltaTime;
            transform.position += (Vector3)directionToPlayer;
        }
    }
    //while <---- loops until statement is false
    //do while x 
    //for   <---- 
    //foreach x
    public void Search()
    {
        // stores closest waypoint
        int closestIndex = -1;
        float closestDistance = float.MaxValue;
        // loop for every waypoint
        //      initializer     condition                  iterator
        for (int index = 0; index <_waypoints.Length; index++)
        //float index = 0;
        //while (index<_waypoints.Length)
        {
            // distance to x waypoint
            float currentDistance = Vector2.Distance(_waypoints[index].position, transform.position);
            //if(distance to x < prev closest waypoint)
            if (currentDistance < closestDistance)
            {
                //the new waypointis the closest
                closestDistance = currentDistance;
                closestIndex = index;
            }
            //index++; ; //increases index by 1
        }
        //_waypointindex == closestIndex;
        _waypointindex = closestIndex;
    }
}
