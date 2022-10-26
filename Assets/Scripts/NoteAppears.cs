using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoteAppears : MonoBehaviour
{
    [SerializeField] private Image NoteImage;
    [SerializeField] private TextMeshProUGUI NoteText;

    [SerializeField] private Image HintImage;
    [SerializeField] private TextMeshProUGUI HintText;


    


    void Update()
    {
        if(HintImage.enabled)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
               HintImage.enabled = false;
               HintText.enabled = false;
               NoteImage.enabled = true;
               NoteText.enabled = true;


            }
            
            

          
        }

    }

    private void OnTriggerEnter(Collider other)
    {
 
        if(other.CompareTag("Player"))
        {
            HintImage.enabled = true;
            HintText.enabled = true;


        }
        

        
           
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            HintImage.enabled = false;
            HintText.enabled = false;
            NoteImage.enabled = false;
            NoteText.enabled = false;

            
        }
    }

    


}
