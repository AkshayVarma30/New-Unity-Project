
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 5f;
    public string enemyTag = "Enemy";
    public float damage = 50f;
    public int igniteChance;
    public GameObject bulletImpactEffect;
    private bool ignitingHit = false;
    public float igniteDuration = 5f;
   // public float igniteDamage = 20f;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Start()
    {
        if (igniteChance != 0)
        {
            float roll = Random.Range(1, 100);
            if (roll <= igniteChance)
            {
                ignitingHit = true;
            }
              
        }
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
           
        moveTheBullet();
        
        
    }
    void moveTheBullet()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * bulletSpeed * Time.deltaTime, Space.World);
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidingObject=collision.gameObject;
        if (collidingObject.tag == enemyTag)
        {
            Destroy(gameObject);
            Instantiate(bulletImpactEffect, transform.position, transform.rotation);
            damageEnemy(collidingObject);
            
        }
        
        
    }
    void damageEnemy(GameObject enemy)
    {
        Enemy enemyScr = enemy.GetComponent<Enemy>();
        enemyScr.hitInfo("Fire", damage);
        if (ignitingHit)
        {
            enemyScr.isIgnited = true;
            enemyScr.igniteInfo(damage / 5, igniteDuration);
        }

    }
}
