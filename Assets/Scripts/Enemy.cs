using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header ("Attributes")]
    private float EnemySpeed;
    private float Health;
    public float MaxHealth;
    public GameObject enemyDeathEffect;

    public Image HealthBar;
    private Transform target;
    public Monsters monsterinfo;
    private int wayPointIndex = 0;
    //public WaveSpawner waveSpawner;

    /*private void Awake()
    {
        monsterinfo = waveSpawner.monster;
    }*/
    private void Start()
    {
        
        target = Waypoints.points[wayPointIndex];
        setAttributes();
        
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
    void setAttributes()
    {
        MaxHealth = monsterinfo.health;
        enemyDeathEffect = monsterinfo.DeathEffect;
        EnemySpeed = monsterinfo.MovementSpeed;
        Health = MaxHealth;
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
        HealthBar.fillAmount = Health / MaxHealth;
        if (Health <= 0)
        {
            Instantiate(enemyDeathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
