using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    [SerializeField] private GameObject light1;
    [SerializeField] private GameObject light2;
    [SerializeField] private GameObject light3;
    [SerializeField] private GameObject light4;
    [SerializeField] private GameObject light5;
    [SerializeField] private GameObject light6;
    [SerializeField] private GameObject light7;
    [SerializeField] private GameObject light8;







    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            light1.GetComponent<Light>().enabled = true;
            light2.GetComponent<Light>().enabled = true;
            light3.GetComponent<Light>().enabled = true;
            light4.GetComponent<Light>().enabled = true;
            light5.GetComponent<Light>().enabled = true;
            light6.GetComponent<Light>().enabled = true;
            light7.GetComponent<Light>().enabled = true;
            light8.GetComponent<Light>().enabled = true;


        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Red"))
        {

            light1.GetComponent<Light>().enabled = false;
            light2.GetComponent<Light>().enabled = false;
            light3.GetComponent<Light>().enabled = false;
            light4.GetComponent<Light>().enabled = false;
            light5.GetComponent<Light>().enabled = false;
            light6.GetComponent<Light>().enabled = false;
            light7.GetComponent<Light>().enabled = false;
            light8.GetComponent<Light>().enabled = false;

        }
    }
}

