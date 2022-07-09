using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject ControlsPanel;

    public void Startgame()
    {
        SceneManager.LoadScene(1);
    }

    public void Opensettings()
    {
        SettingPanel.SetActive(true);
    }

    public void Closesettings()
    {
        SettingPanel.SetActive(false);
    }

    public void Exitgame()
    {
        Debug.Log("A sair");
        Application.Quit();
    }

    public void OpenControls()
    {
        ControlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        ControlsPanel.SetActive(false);
    }
}
