
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class button : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{
    public Color hoverColor=Color.red;
    public RadialMenu myMenu;
    public int buttonIndex;
    public GameObject towerPrefab;

    public void OnPointerEnter(PointerEventData eventData)
    {
        myMenu.selectedButton = this;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myMenu.selectedButton = null;
    }
}
