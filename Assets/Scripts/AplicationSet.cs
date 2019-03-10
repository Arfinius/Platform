using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicationSet : MonoBehaviour {

    private void Awake()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;
        Screen.orientation = ScreenOrientation.Landscape;

    }
}
