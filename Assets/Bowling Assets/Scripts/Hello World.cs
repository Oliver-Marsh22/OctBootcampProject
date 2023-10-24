using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public int numberVariable; // variable declaration
    public bool isDoingSomething = false; //variable initialization
    public float speed = 10.0f;
    public string name = "rizz";
    public Vector3 targetPosition;
    public Transform cubeTransform;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        isDoingSomething = true; //variable assignment
        Debug.Log("hello world from start");
        Debug.Log("the variables are " + this);

        cubeTransform.position = position;
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        Debug.Log("The number variable is: " + numberVariable);
        //cubeTransform.Translate(Vector3.forward * Time.deltaTime * speed);
       if(isDoingSomething == true)
        {
        cubeTransform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
        

    }
}
