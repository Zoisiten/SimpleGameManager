using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel
{

    public void SetGameObjectAction(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}
