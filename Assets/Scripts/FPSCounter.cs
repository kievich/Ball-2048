using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour
{

    string label = "";
    private float timeFromLastDisplay;
    private int framesPassed = 0;
    private float fpsTotal = 0f;
    private GUIStyle guiStyle = new GUIStyle();


    private void Update()
    {

        float fps = 1 / Time.unscaledDeltaTime;
        fpsTotal += fps;
     

        framesPassed++;
        timeFromLastDisplay += Time.deltaTime;

        if (timeFromLastDisplay > 0.5f)
        {

            label = "FPS: " + System.Math.Round(fps, 0)
                + "\nAVG: " + System.Math.Round(fpsTotal / framesPassed, 2);
        
            timeFromLastDisplay = 0;
        }

    }

    void OnGUI()
    {
        guiStyle.fontSize = 30;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(5, 40, 200, 200), label, guiStyle);

    }
}