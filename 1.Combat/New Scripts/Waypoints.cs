using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;
    public void OnDrawGizmos()
    {
        foreach(Transform t in transform) 
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }   
        Gizmos.color= Color.red;
        for(int i = 0; i < transform.childCount-1; i++) 
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
        }
        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
    }

    public Transform GetNextWaypoint(Transform currrentWaypoint) 
    {
        if (currrentWaypoint == null) 
        {
            return transform.GetChild(0);
        }
        if (currrentWaypoint.GetSiblingIndex()< transform.childCount -1) 
        {
            return transform.GetChild(currrentWaypoint.GetSiblingIndex()+1);
        }
        else
        {
            return transform.GetChild(0);
        }
    }
}
