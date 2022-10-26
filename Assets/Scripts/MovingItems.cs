using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingItems : MonoBehaviour
{
   
    [SerializeField] private Animator Anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            this.GetComponent<Animator>().SetTrigger("Moving");
        }
    }
}
