using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Final : MonoBehaviour
{
  public void PlayGame () 

{
   SceneManager.LoadScene("level09");
}

public void Menu ()
{
  SceneManager.LoadScene("start");
}

 public void QuitGame ()

{
  Debug.Log("QUIT!");
  Application.Quit();
}
}
