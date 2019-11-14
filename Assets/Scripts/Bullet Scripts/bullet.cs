
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 5f;
    public string enemyTag = "Enemy";
    public float damage = 50f;
    public GameObject bulletImpactEffect = null;
    public float explosionRadius = 10f;
   
    public int soakChance;
    public int igniteChance;
    public int shockChance;
    public int stunChance;
    public int knockbackChance;
    public int tangleChance;

    private string rolledAilment = null;



    public void Seek(Transform _target)
    {
        target = _target;
    }
    string rollForAilment()
    {
       
        if (soakChance != 0)
        {
            float roll = Random.Range(0.01f, 1f);
            if (roll <= soakChance)
                return "soaked";
        }
        
        return null;
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
        if (Vector3.Distance(target.position, transform.position) <= 0.1f)
        {
            hitTarget();
        }
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        GameObject collidingObject=collision.gameObject;
        if (collidingObject.tag == enemyTag)
        {
            Destroy(gameObject);
            if (bulletImpactEffect != null)
            {
                Instantiate(bulletImpactEffect, transform.position, transform.rotation);
            }
            
            damageEnemy(collidingObject);
        }
        
        
    }*/
    void damageEnemy(GameObject enemy)
    {
        Enemy enemyScr = enemy.GetComponent<Enemy>();
       // enemyScr.takingDamage(damage);
    }

    void hitTarget()
    {
        if (explosionRadius != 0)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach(Collider item in colliders)
            {
                if (item.tag == enemyTag)
                {
                    damageEnemy(item.gameObject);
                }
            }
        }
        else
        {
            damageEnemy(target.gameObject);
        }
    }
}

