
using UnityEngine;

public class capsule : MonoBehaviour
{
    [System.Serializable]
    public class towerButtons
    {
        public Color color;
        public button sprite;
        public GameObject tower;
    }
    public towerButtons[] arrayOfButtons;

    public Color hoverColor;
    public Renderer rend;
    public Vector3 positionOffset;
    void Start()
    {
       
        rend = gameObject.GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = Color.white;
    }
    private void OnMouseDown()
    { 
            RadialMenuSpawner.instance.spawnMenu(this);
    }
    public void towerBuildingAI(int i)
    {
        Debug.Log("working!");
        Destroy(gameObject);
        Instantiate(arrayOfButtons[i].tower, transform.position+positionOffset, transform.rotation);
    }

}
