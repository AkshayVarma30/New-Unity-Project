
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class HitDamage : MonoBehaviour
{
    public Enemy enemy;
    public string damageType;
    public float damage;

    private void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
    }

    private void Update()
    {
        
    }
    public void calculateDamage(string damageT, float dmg)
    {
        //Debug.Log("inside cdmg");
        damage = dmg;
        damageType = damageT;
        float damageResistance = getDamageResistance();
        float finaldamage = damage * ((100 - damageResistance) / 100);
        enemy.takingDamage(finaldamage);

    }

    float getDamageResistance()
    {
        return 0f;
    }
   
}
