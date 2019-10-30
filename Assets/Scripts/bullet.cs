
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    public float bulletSpeed = 5f;
    public string enemyTag = "Enemy";
    public float damage = 50f;
    public GameObject bulletImpactEffect;
    public int igniteChance;
    public int soakChance;
    public int stunChance;
    public int shockChance;
    public int tangleChance;
    public int knockbackChance;

    private string rolledAilment = null;



    public void Seek(Transform _target)
    {
        target = _target;
    }
    string rollForAilment()
    {
        if (igniteChance != 0)
        {
            float roll = Random.Range(0.01f, 1f);
            if (roll <= igniteChance)
                return "ignited";
        }
        if (soakChance != 0)
        {
            float roll = Random.Range(0.01f, 1f);
            if (roll <= soakChance)
                return "soaked";
        }
        if (stunChance != 0)
        {
            float roll = Random.Range(0.01f, 1f);
            if (roll <= stunChance)
                return "stunned";
        }
        if (shockChance != 0)
        {
            float roll = Random.Range(0.01f, 1f);
            if (roll <= shockChance)
                return "shocked";
        }
        if (knockbackChance != 0)
        {
            float roll = Random.Range(0.01f, 1f);
            if (roll <= knockbackChance)
                return "knockedback";
        }
        if (tangleChance != 0)
        {
            float roll = Random.Range(0.01f, 1f);
            if (roll <=tangleChance)
                return "tangled";
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
