using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
void Start ()
{
FindObjectOfType<AudioManager>().Play("haven");
Admanager.instance.RequestBanner();
}

   public void PlayGame () 

{  
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   Admanager.instance.HideBanner();
}

   public void QuitGame ()

{
  Debug.Log("QUIT!");
  Application.Quit();
}

}
