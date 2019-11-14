using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignite : MonoBehaviour
{
    public float igniteDamage;
    public bool canBeIgnited = false;
    public bool isIgnited = false;
    public int fireResistance = 0;
    public GameObject igniteParticleEffect;
    public float igniteDuration = 5f;
    float igniteTickTimer = 0f;

    public Enemy enemy;
  

    void Update()
    {
        if (isIgnited)
        {
            if (igniteTickTimer <= 0)
            {
                igniteEnemy();
            }
            igniteTickTimer -= Time.deltaTime;
        }
        if (igniteDuration <= 0)
        {
            stopIgnite();
        }
    }

    void igniteEnemy()
    {
       // enemy.takingDamage(igniteDamage);
        igniteTickTimer = 1f;
    }

    void stopIgnite()
    {
        isIgnited = false;
    }
}
