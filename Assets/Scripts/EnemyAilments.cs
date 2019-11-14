
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyAilments : MonoBehaviour
{
    public Enemy enemy;


    private bool igniteEffectOn = false;
    private GameObject instantiatedIPE;
    private float igniteTickTimer = 1f;
    public float igniteDuration;
    public GameObject igniteParticleEffect;
    public float igniteDamage;

    private void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
    }

    void Update()
    {
        
        if (enemy.isIgnited)
        {
            if (!igniteEffectOn)
            {
                instantiatedIPE = Instantiate(igniteParticleEffect, transform.position, transform.rotation);
                igniteEffectOn = true;
                
            }
            else
            {
                instantiatedIPE.transform.position = transform.position;
            }
            if (igniteTickTimer <= 0)
            {
                igniteEnemy();
            }
            if (igniteDuration <= 0)
            {
                stopIgnite();
            }
            
            igniteTickTimer -= Time.deltaTime;
            igniteDuration -= Time.deltaTime;
        }
        
    }
    private void OnDestroy()
    {
        Destroy(instantiatedIPE);
    }
    void igniteEnemy()
    {
        enemy.takingDamage(igniteDamage);
        igniteTickTimer = 1f;
    }

    void stopIgnite()
    {
        enemy.isIgnited = false;
        Destroy(instantiatedIPE);
    }
    
}
