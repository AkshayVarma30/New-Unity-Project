
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireTower : MonoBehaviour
{
    [Header("Attributes")]
    public float damage = 50f;
    public float Range = 15f;
    public float rotationSpeed = 1f;
    public float fireRate = 2f;
    private float frCountdown = 0f;
    public int igniteChance;
    public int noOfProjectiles = 1;
    /*public int soakChance;
    public int stunChance;
    public int shockChance;
    public int tangleChance;
    public int KnockbackChance;*/

    [Header("Unity Settings")]
    public string enemytag = "Enemy";
    public GameObject bulletPrefab;
    public Transform spawnPoint;

    List<GameObject> targets = new List<GameObject>(); 
    //public GameObject target = null;
    public GameObject partToRotate = null;

    private Renderer rend;
    public Color highLightColor=Color.red;
    

    private void Start()
    {
        InvokeRepeating("targetSelector", 0f, 0.1f);
        
        
    }
    
        
    
    //code for range generation
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    //code to select the target
    /*void targetSelector()
    {
        //array that contain all the enemies spawned
        List<GameObject> enemies = new List<GameObject>();
        //GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag(enemytag).ToList();
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
       // while (targets.Count <= noOfProjectiles)
       // {
           
            //code to find the nearest enemy
            foreach (GameObject enemy in enemies)
            {
                float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (enemyDistance < shortestDistance)
                {
                    shortestDistance = enemyDistance;
                    nearestEnemy = enemy;
                    //enemies.Remove(enemy);
                }
                if (nearestEnemy != null && shortestDistance <= Range)
                {
                   /* if (targets != null)
                    {
                        foreach(GameObject target in targets)
                        {
                            if (Vector3.Distance(target.transform.position, transform.position) >= Range)
                            {



                            }
                            else
                                return;
                        }
                        
                    }
                    targets.Add(nearestEnemy);

                }
                else
                {
                    targets = null;
                }
            }
        
            
       // }
       
        
             
    }*/
    void targetSelector()
    {
        targets.Clear();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance <= Range)
            {
                targets.Add(enemy);
            }

        }

    }
    void Update()
    {
        if (targets == null)
        {
            //Debug.Log("null");
            return;
        }
        /*if (partToRotate != null)
            rotateBarrel();*/
        
        
        if (frCountdown <= 0)
        {
            shoot();
            frCountdown = 1 / fireRate;
        }
        frCountdown -= Time.deltaTime;
    }
    
    void shoot()
    {
        int spawnedProjectiles = 0;
       //while (spawnedProjectiles < noOfProjectiles)
       // {
            foreach (GameObject target in targets)
            {
            
                if (target != null)
                {
                    GameObject bulletGO = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                    spawnedProjectiles++;
                    fireBullet bullet = bulletGO.GetComponent<fireBullet>();
                    {
                        bullet.damage = this.damage;
                        bullet.igniteChance = igniteChance;
                        /*bullet.shockChance = shockChance;
                        bullet.soakChance = soakChance;
                        bullet.stunChance = stunChance;
                        bullet.tangleChance = tangleChance;
                        bullet.knockbackChance = KnockbackChance;*/
                    }
                    bullet.Seek(target.transform);
                }
            }
            
            
       // }
        
    }
    /*void rotateBarrel()
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookDirection = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.transform.rotation, lookDirection, rotationSpeed * Time.deltaTime).eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }*/
}
