using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float EnemySpeed = 10f;
    public float Health = 100f;
    public GameObject enemyDestroyEffect;
    private int wayPointIndex = 0;
    private void Start()
    {
        target = Waypoints.points[wayPointIndex];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * EnemySpeed * Time.deltaTime, Space.World);
        if (Vector3.Distance(target.position, transform.position) < 0.2f)
        {
            nextWayPointIndex();
        }
    }
    void nextWayPointIndex()
    {
        if (wayPointIndex>=Waypoints.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        
            wayPointIndex++;
            target = Waypoints.points[wayPointIndex];
        
    }

    public void takingDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Instantiate(enemyDestroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
