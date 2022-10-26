using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject PuzzleCamera;

   


    public void CamSwitch()
    {
        mainCamera.SetActive(false);
        PuzzleCamera.SetActive(true);
        
    }

    public void RevertCam()
    {
        mainCamera.SetActive(true);
        PuzzleCamera.SetActive(false);
    }
}
