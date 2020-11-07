using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour {
public Slider slider;
public Text progressText;
public GameObject loadingScreen;   
public void LoadLevel (int seceneIndex)

{
   StartCoroutine(LoadAsynchronously(seceneIndex));
   
}

 IEnumerator LoadAsynchronously (int seceneIndex)
{
AsyncOperation operation = SceneManager.LoadSceneAsync(seceneIndex);

loadingScreen.SetActive(true);

while (!operation.isDone)
{
    float progress = Mathf.Clamp01(operation.progress / .9f);
    slider.value = progress;
    progressText.text = progress * 100 + "%";

    yield return null;
}

}
public void PlayGame () 

{
   SceneManager.LoadScene("start");
}
    
}
