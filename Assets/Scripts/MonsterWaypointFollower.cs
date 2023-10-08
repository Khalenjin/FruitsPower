using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

            // Waypoint'e �arp�nca y ekseni etraf�nda rotasyonu ayarla
            if (currentWaypointIndex % 2 == 0) // �ift waypoint indeksi
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else // Tek waypoint indeksi
            {
                transform.eulerAngles = new Vector3(0, 180f, 0);
            }
        }

        Vector2 targetPosition = waypoints[currentWaypointIndex].transform.position;

        // Pozisyonu hedefe do�ru g�ncelle
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }
}
