using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PressKey : MonoBehaviour
{
    [SerializeField] private GameObject UIelemnt;
   // public KeyScript Key;
    [SerializeField] private GameObject player;


    //  [SerilizeField] private GameObject UIelemnt;

    // Start is called before the first frame update
    //  public int key = 0;

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && player.GetComponent<KeyScript>().key > 0)
        {
           // player.GetComponent<KeyScript>().key--;

            UIelemnt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("ScientistRoom");
            }

            // Text.SetActive(true);
            // open = true;
        }
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIelemnt.SetActive(false);

        }
    }
}
