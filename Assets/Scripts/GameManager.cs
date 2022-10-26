
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 

 public class GameManager : MonoBehaviour
  {
    [SerializeField] private Text gameClock;
    [SerializeField] private int timeLeft;
 

     private void Start()
    {
	  
     InvokeRepeating("Countdown", 1, 1);
   
    }

     private void Update()
     {

       gameClock.text = ("" + timeLeft) ;
  
       if (timeLeft < 0)
       SceneManager .LoadScene(SceneManager .GetActiveScene().name) ;

	 }

    private void Countdown()
    {
		
     timeLeft--;
	 
    }

}