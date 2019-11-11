using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoETurret : MonoBehaviour
{
    [Header("Attributes")]
    public float damageOverTime = 100f;
    public float Range = 15f;
    /*public float fireRate = 2f;
    private float frCountdown = 0f;*/
    public int igniteChance;
    public int soakChance;
    public int stunChance;
    public int shockChance;
    public int tangleChance;
    public int KnockbackChance;

    [Header("Unity Settings")]
    public string enemytag = "Enemy";
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    //public float hitsPerSecond

    //public GameObject target = null;
    List<GameObject> targets = new List<GameObject>();

    private Renderer rend;
    public Color highLightColor = Color.red;


    private void Start()
    {
        InvokeRepeating("targetSelector", 0f, 0.2f);


    }



    //code for range generation
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    //code to select the target
    void targetSelector()
    {
        targets.Clear();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < Range)
            {
                targets.Add(enemy);
            }

        }

    }
    void Update()
    {
        if (targets.Count != 0)
        {
            foreach (GameObject enemy in targets)
            {
               //Debug.Log("here");
                if (enemy == null)
                {
                    return;
                }

                
                //Debug.Log(Time.deltaTime);
                enemy.GetComponent<Enemy>().takingDamage(damageOverTime * Time.deltaTime); ;
                
            }
        }
        
    }

}

