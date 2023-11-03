using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuCamController : MonoBehaviour
{   
    public GameObject menuCam;
   public void CreditsRotation()
    {
        menuCam.transform.Rotate(0.0f, -90f, 0.0f);
    }
    public void ControlsRotation()
    {
        menuCam.transform.Rotate(0.0f, 90f, 0.0f);
    }
}
