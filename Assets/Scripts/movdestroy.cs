using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movdestroy : MonoBehaviour
{

    [SerializeField] private Animator Anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            this.GetComponent<Animator>().SetTrigger("Moving");
            Invoke(nameof(Destroy),5);


        }
    }
    void Destroy()
    {
        Destroy(gameObject);

    }
}
