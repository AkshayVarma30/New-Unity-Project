
using UnityEngine;
[CreateAssetMenu(fileName ="New Enemy",menuName ="ScriptableObjects/Monster")]
public class Monster : ScriptableObject
{
    public float health;
    public float movementSpeed;
    public Color monsterColor;
    public GameObject deathEffect;
    public int fireResistance;
    public int waterResistance;
    public int lightningResistance;
    public int earthResistance;
    public int airResistance;
    public int natureResistance;
    public bool canBeIgnited;
    public bool canBeSoaked;
    public bool canBeShocked;
    public bool canBeStunned;
    public bool canBeknockedback;
    public bool canBeTangled;








}
