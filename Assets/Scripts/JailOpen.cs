using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JailOpen : MonoBehaviour
{


    [SerializeField] private Image HintImage;
    [SerializeField] private TextMeshProUGUI HintText;

    [SerializeField] private Animator anim;
    //[SerializeField] private GameObject theDoor;
    public SoundManager sm;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    


    void Update()
    {
        if(HintImage.enabled)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
               HintImage.enabled = false;
               HintText.enabled = false;
               sm.PlayOpenDoor();
               anim.Play("JailOpen");


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


            
        }
    }

    


}
