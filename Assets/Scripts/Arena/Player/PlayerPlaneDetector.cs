using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaneDetector : MonoBehaviour
{
    bool insidePlane = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (insidePlane)
        {

        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlackSmith"))
        {
            insidePlane = true;
            Debug.Log("Player enter BlackSmith.");
        }
        else if (other.CompareTag("MageTower"))
        {
            insidePlane = true;
            Debug.Log("Player enter MageTower.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BlackSmith"))
        {
            insidePlane = false;
            Debug.Log("Player exited Blacksmith.");
        }
        else if (other.CompareTag("MageTower"))
        {
            insidePlane = false;
            Debug.Log("Player exited MageTower.");
        }
    }
}
