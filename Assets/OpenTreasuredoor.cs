using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTreasuredoor : MonoBehaviour
{
    public static int counter = 0;

     private GameObject blueRoom;

    private GameObject RedRoom;

     private GameObject GreenRoom;

     private GameObject YellowRoom;
      public GameObject CamScene;

   /* void OnTriggerStay(Collider other)
    {
       /* if (this.CompareTag("blue"))
        {
            if (blueRoom.activeSelf==true)
            {
                counter++;
            }
        }
        if (this.CompareTag("Red"))
        {
            if (RedRoom.activeSelf==true)
            {
                counter++;
            }
        }
        if (this.CompareTag("Green"))
        {
            if (GreenRoom.activeSelf==true)
            {
                counter++;
            }
        }

        if (this.CompareTag("yellow"))
        {
            if (YellowRoom.activeSelf== true)
            {
                counter++;
            }
        } 
    } */
    void Update()
    {
        if (counter >= 4)
        {
          CamScene.SetActive(true);
            Debug.Log("gggg");
        }
    }
     

}

