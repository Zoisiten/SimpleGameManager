using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScale : MonoBehaviour
{
    private int screenWidth;
    private int screenHeight;
    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Screen.height;
        GetComponent<CanvasScaler>().scaleFactor = screenHeight/(float)2688;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
