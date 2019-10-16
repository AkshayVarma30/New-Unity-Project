using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuSpawner : MonoBehaviour
{
    public static RadialMenuSpawner instance;
    public RadialMenu menu;
    public int selectedButtonIndex;

    private void Awake()
    {
        instance = this;
    }
    public void spawnMenu(capsule obj)
    {
            RadialMenu newMenu = Instantiate(menu, transform);
            newMenu.transform.position = Input.mousePosition;
            newMenu.spawnButtons(obj);
    }
}
