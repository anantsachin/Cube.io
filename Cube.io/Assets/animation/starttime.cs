using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starttime : MonoBehaviour {


    public int countdownTime;
    public Text countdownDisplay;
    
    private void Start()
    {
    StartCoroutine(CountdownTostart());
    }
    
    IEnumerator CountdownTostart()
{
    while(countdownTime > 0)
    {
    countdownDisplay.text = countdownTime.ToString();
    
    yield return new WaitForSeconds(1f);
    
    countdownTime--;
    }


    countdownDisplay.text="GO!";
    
    yield return new WaitForSeconds(1f);
    countdownDisplay.gameObject.SetActive(false);
    }
}
