using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameScene;
    
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void back()
    {
      SceneManager.LoadScene("WinScene");
    }
    
    public void Credits()
    {
      SceneManager.LoadScene("Credits");
    } 

    // Update is called once per frame
    public void QuitGame()
    {
       Application.Quit();
        
    }
  

}