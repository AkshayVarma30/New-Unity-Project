using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    public float Range = 15f;
    public float rotationSpeed = 1f;
    public float fireRate = 2f;
    private float frCountdown = 0f;
    [Header("Unity Settings")]
    public string enemytag = "Enemy";
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    
    public GameObject target = null;
    public GameObject partToRotate;

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
                        //Debug.Log("target is changed to"+shortestDistance);
                        target = nearestEnemy;
                        /*rend = target.GetComponent<Renderer>();
                        rend.material.color = highLightColor;*/
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
       /* float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        if (targetDistance >= Range)
        {

        }*/
        
             
    }
    void Update()
    {
        if (target == null)
        {
            //Debug.Log("null");
            return;
        }
            
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
