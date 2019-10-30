
using UnityEngine;

[System.Serializable]
public class Monsters : MonoBehaviour
{
    public Monster monster;
    public int randoom;
     public Monsters(Monster monster,int random)
    {
        this.monster = monster;
        this.randoom = random;
    }
    
}
