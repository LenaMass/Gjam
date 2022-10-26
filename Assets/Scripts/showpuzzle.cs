using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class showpuzzle : MonoBehaviour
{
    [SerializeField] private Image puzzle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //open door consition
            Debug.Log("Solve the puzzle ");
            puzzle.enabled = true;
        }  
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //open door consition
            puzzle.enabled = false;
        }
    }
}
