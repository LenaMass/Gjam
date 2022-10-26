using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShelf : MonoBehaviour
{
    [SerializeField] private Animator Anim;
     public SoundManager sm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
           sm.PlayShelfmovement();
            this.GetComponent<Animator>().SetTrigger("IsMoving");
        }
    }
}