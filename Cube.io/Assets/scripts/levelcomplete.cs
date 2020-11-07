
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcomplete : MonoBehaviour {

 public void LoadNextLevel ()

{  
  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}

}
