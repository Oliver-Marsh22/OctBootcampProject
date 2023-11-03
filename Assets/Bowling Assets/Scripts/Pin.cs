using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool isFallen;
    public float pinFallAccuracy = 5f;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private Rigidbody pinRb;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        pinRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf)
        {
            isFallen = Quaternion.Angle(startRotation, transform.localRotation) > pinFallAccuracy;
        }
        //check if pin has fallen
       

    }

    public void ResetPin()
    {
        gameObject.SetActive(true);
        pinRb.isKinematic = true;
        pinRb.velocity = Vector3.zero;
        transform.position = startPosition;
        transform.rotation = startRotation;
        isFallen = false;
        pinRb.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pit"))
        {
            isFallen=true;
        }
    }
}
