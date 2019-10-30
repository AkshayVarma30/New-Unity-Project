using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    public button buttonPrefab;
    public button selectedButton;
    private int selectedButtonIndex=-1;
   
    capsule obj1;

    public void spawnButtons(capsule obj)
    {
        obj1 = obj;
        for(int i = 0; i < obj.arrayOfButtons.Length; i++)
        {
            button newbutton = Instantiate(buttonPrefab, transform);
            float theta = (2 * Mathf.PI / obj.arrayOfButtons.Length) * i;
            float xpos = Mathf.Sin(theta);
            float ypos = Mathf.Cos(theta);
            newbutton.transform.localPosition = new Vector3(xpos, ypos, 0f)*50f;
            newbutton.myMenu = this;
            newbutton.buttonIndex = i;
            newbutton.towerPrefab = obj.arrayOfButtons[i].tower;
        }
        
        
        
    }
    void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            if (selectedButton != null)
            {
                selectedButtonIndex = selectedButton.buttonIndex;
                obj1.towerBuildingAI(selectedButtonIndex);
                
            }
            Destroy(gameObject);
        }
    }
}
