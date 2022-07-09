using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        StatusPlayer.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        StatusPlayer.OnPlayerDeath -= GameOver;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
