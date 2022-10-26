using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLight : MonoBehaviour
{
    [SerializeField] private GameObject Room;
   // public static int _triggerCounter;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green"))
        {
            OpenTreasuredoor.counter++;
           // Debug.Log("Light Trigger Counter :"+_triggerCounter);
            Room.GetComponent<Light>().enabled = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Green"))
        {
            Room.GetComponent<Light>().enabled = false;
        }
    }
}

