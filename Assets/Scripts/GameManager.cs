using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
 

    public void GameOver()
    {
        UIManager.Instance.gameUI.gameOver.SetActive(true);
        Time.timeScale = 0;
    }

 
}
