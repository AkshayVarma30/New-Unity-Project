
using UnityEngine;

public class capsule : MonoBehaviour
{
    public Color hoverColor;
    public Renderer rend;
    public GameObject towerPrefab;
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
        towerBuildingAI();   
    }
    void towerBuildingAI()
    {
        Debug.Log("working!");
        Destroy(gameObject);
        Instantiate(towerPrefab, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
