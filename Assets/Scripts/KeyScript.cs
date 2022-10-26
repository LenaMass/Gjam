using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyScript : MonoBehaviour
{
   // [SerializeField] private Text Keyno;
    public int key = 0;


    void Update()
    {
        //   transform.Rotate(90 * Time.deltaTime, 0, 0);
       // Keyno.text = ("" + key);

    }
   public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            //   AudioSource audioSource = this.GetComponent<AudioSource>();
            Destroy(other.gameObject);
            //  audioSource.Play();
            key++;

            Debug.Log("You Got : " + key);
        }
        /* if (other.gameObject.tag == "Enemy")
         {

             Destroy(other.gameObject);
             Enemy++;
             Debug.Log("Enemy: " + Enemy);
         }*/

    }
}