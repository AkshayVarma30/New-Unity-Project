using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    public float damage = 50f;
    public float Range = 15f;
    public float rotationSpeed = 1f;
    public float fireRate = 2f;
    private float frCountdown = 0f;
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
    
    public GameObject target = null;
    public GameObject partToRotate = null;

    private Renderer rend;
    public Color highLightColor=Color.red;
    

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
        //array that contain all the enemies spawned
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        //code to find the nearest enemy
        foreach (GameObject enemy in enemies) 
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < shortestDistance)
            {
                shortestDistance = enemyDistance;
                nearestEnemy = enemy;
            }
            if (nearestEnemy!=null && shortestDistance <= Range)
            {
                if (target != null )
                {
                    if (Vector3.Distance(target.transform.position, transform.position) >= Range)
                    {
                        
                        target = nearestEnemy;
                        
                    }
                    else
                        return;
                }
                target = nearestEnemy;

            }
            else
            {
                target = null;
            }
            
        }
       
        
             
    }
    void Update()
    {
        if (target == null)
        {
            //Debug.Log("null");
            return;
        }
        if (partToRotate != null)
            rotateBarrel();
        
        
        if (frCountdown <= 0)
        {
            shoot();
            frCountdown = 1 / fireRate;
        }
        frCountdown -= Time.deltaTime;
    }
    
    void shoot()
    {
        GameObject bulletGO=Instantiate(bulletPrefab, spawnPoint.position,spawnPoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();
        {
            bullet.damage = this.damage;
            bullet.igniteChance = igniteChance;
            bullet.shockChance = shockChance;
            bullet.soakChance = soakChance;
            bullet.stunChance = stunChance;
            bullet.tangleChance = tangleChance;
            bullet.knockbackChance = KnockbackChance;
        }
        bullet.Seek(target.transform);
    }
    void rotateBarrel()
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookDirection = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.transform.rotation, lookDirection, rotationSpeed * Time.deltaTime).eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
