using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatForm : MonoBehaviour
{
    public Vector3[] points;
    public int point_Number = 0;
    private Vector3 Current_target;

    public float tolerance;
    public float PlatformSpeed;
    public float delay_time;

    private float delay_start;

    public bool automatic;

    void Start()
    {
        if(points.Length > 0)//intialisng the first point the platform is to go to
        {
            Current_target = points[0];
        }
        tolerance = PlatformSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if(transform.localPosition != Current_target)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }
    }

    void MovePlatform()
    {
        Vector3 Heading = Current_target - transform.localPosition;//the direction the platfrom is going
        transform.localPosition += (Heading / Heading.magnitude) * PlatformSpeed * Time.deltaTime;//normalised vector
        if(Heading.magnitude <tolerance)//allowed gap between the target point and current point
        {
            transform.localPosition = Current_target;
            delay_start = Time.time;//starts the delay before platform moves again
        }
    }

    void UpdateTarget()
    {
        if (automatic)
        {
            if(Time.time - delay_start > delay_time)//delay before it Moves again
            {
                NextPlatform();
            }
        }
    }

    void NextPlatform()
    {
        point_Number++;
        if(point_Number >= points.Length)//cycle throug the array of points
        {
            point_Number = 0;
        }
        Current_target = points[point_Number];
    }

    //making the platform the parent of the player so they move with the platform
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
