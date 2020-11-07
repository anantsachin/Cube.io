
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour {

	public string nextLevel = "Level02";
    public int levelToUnlock = 2;
	bool gameHasEnded = false;

	public float restartDelay = 1f;

	public GameObject completeLevelUI;
    public GameObject EndscreenUI;

    

	public void CompleteLevel ()
	{
                Debug.Log("level completed");
		completeLevelUI.SetActive(true);
		if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
{
      PlayerPrefs.SetInt("levelReached", levelToUnlock);
}
	}

	public void EndGame ()
	{
		if (gameHasEnded == false)
        {
            Admanager.instance.showfullscreenAd();
			
			gameHasEnded = true;
			Debug.Log("GAME OVER");
            EndscreenUI.SetActive(true);
		}
	}

    public void ReciveReward()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
