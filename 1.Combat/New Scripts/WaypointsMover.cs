using UnityEngine;

public class WaypointsMover : MonoBehaviour
{
    private Waypoints waypoints;
    public float moveSpeed = 10f;
    public float distanceThreshold = 0.1f;

    private Transform currentWaypoint;

    void Start()
    {
        GameObject waypointsObject = GameObject.Find("Waypoints");
        if (waypointsObject != null)
        {
            waypoints = waypointsObject.GetComponent<Waypoints>();
            if (waypoints != null)
            {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                transform.position = currentWaypoint.position;
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            }
        }
    }

    void Update()
    {
        if (waypoints == null)
            return;

        if (currentWaypoint == waypoints.transform.GetChild(1))
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, 20 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        }
    }
}
