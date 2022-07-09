using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public BoardManager boardScript;
    public float levelStartDelay = 0.3f;

    private Text LevelText;
    private GameObject LevelImage;
    private int level = 0;
    private bool doingSetup;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    private void OnLevelWasLoaded(int index)
    {
        level++;
        InitGame();
    }

    void InitGame()
    {
        doingSetup = true;
        LevelImage = GameObject.Find("LevelImage");
        LevelText = GameObject.Find("LevelText").GetComponent<Text>();
        LevelText.text = "Dia " + level;       
        LevelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);
        boardScript.SetupScene(level);
    }

    private void HideLevelImage()
    {
        LevelImage.SetActive(false);
        doingSetup = false;

    }
}
