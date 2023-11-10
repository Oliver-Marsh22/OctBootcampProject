using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MenuCamController : MonoBehaviour
{   
    public GameObject backButton;

    public float target;
    float r;
    bool isRot  = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target , ref r, 0.1f );
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        if ( isRot == true)
        {
            backButton.SetActive( true );
        }else
        {
            backButton.SetActive( false );
        }
        
    }

    public void ChangeAngle(float targetAngle)
    {
        
        target = targetAngle;
        isRot = true;
    }
    public void ChangeAngle2(float targetAngle)
    {

        target = targetAngle;
        isRot = false;
    }
}
