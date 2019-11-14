
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header ("Attributes")]
    private float EnemySpeed;
    public float Health;
    public float MaxHealth;
    public GameObject enemyDeathEffect;

    [Header("Enemy Resistances.. no need to change")]
    public int fireResistance;
    public int waterResistance;
    public int lightningResistance;
    public int earthResistance;
    public int airResistance;
    public int natureResistance;

    [Header("Enemy Ailment Props.. no need to change")]
    public bool canBeIgnited;
    public bool canBeSoaked;
    public bool canBeShocked;
    public bool canBeStunned;
    public bool canBeknockedback;
    public bool canBeTangled;

    public bool isIgnited = false;
    public bool isSoaked = false;
    public bool isShocked = false;
    public bool isStunned = false;
    public bool isknockedback = false;
    public bool isTangled = false;


    public Image HealthBar;
    private Transform target;
    public Monster monsterinfo;
    private int wayPointIndex = 0;

   
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
        enemyDeathEffect = monsterinfo.deathEffect;
        EnemySpeed = monsterinfo.movementSpeed;
        Health = MaxHealth;
        gameObject.GetComponent<Renderer>().material.color = monsterinfo.monsterColor;

        fireResistance = monsterinfo.fireResistance;
        waterResistance = monsterinfo.waterResistance;
        lightningResistance = monsterinfo.lightningResistance;
        earthResistance = monsterinfo.earthResistance;
        airResistance = monsterinfo.airResistance;
        natureResistance = monsterinfo.natureResistance;

        canBeIgnited = monsterinfo.canBeIgnited;
        canBeSoaked = monsterinfo.canBeSoaked;
        canBeShocked = monsterinfo.canBeShocked;
        canBeStunned = monsterinfo.canBeStunned;
        canBeknockedback = monsterinfo.canBeknockedback;
        canBeTangled = monsterinfo.canBeTangled;



        gameObject.GetComponent<EnemyAilments>().enemy = this;
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
        //Debug.Log("Health = " + Health);
        //Debug.Log("damage = "+ damage);
        Health -= damage;
        HealthBar.fillAmount = Health / MaxHealth;
        if (Health <= 0)
        {
            //Debug.Log("here");
            GameObject DE=Instantiate(enemyDeathEffect, transform.position, transform.rotation);
            
            Destroy(gameObject);
            Destroy(DE, 2f);
        }
    }
    

    public void hitInfo(string damageType, float damage)
    {
        gameObject.GetComponent<HitDamage>().calculateDamage(damageType,damage);
    }

    public void igniteInfo(float igniteDps, float igniteDuration)
    {
        gameObject.GetComponent<EnemyAilments>().igniteDuration = igniteDuration;
        gameObject.GetComponent<EnemyAilments>().igniteDamage = igniteDps;
    }

    public void soakInfo()
    {

    }

    public void shockInfo()
    {

    }

    public void knockbackInfo()
    {

    }

    public void stunInfo()
    {

    }

    public void tangleInfo()
    {

    }
}
