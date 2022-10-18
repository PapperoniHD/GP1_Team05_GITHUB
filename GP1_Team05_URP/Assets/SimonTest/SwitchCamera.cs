using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondCamera;

    
    // Function to disable Main Camera and enable Second Camera
    public void ShowSecondCameraView()
    {
        mainCamera.enabled = false;
        secondCamera.enabled = true;
    }

    // Function to enable Main Camera and disable Second Camera
    public void ShowMainCameraView()
    {
        mainCamera.enabled = true;
        secondCamera.enabled = false;
    }
}
