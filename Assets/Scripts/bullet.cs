
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 5f;
    public string enemyTag = "Enemy";
    public float damage = 50f;
    public GameObject bulletImpactEffect;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
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
        enemyScr.takingDamage(damage);
        

    }
}
