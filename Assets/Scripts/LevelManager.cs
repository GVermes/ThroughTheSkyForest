using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager lm;

    private void Awake()
    {
        lm = this;
    }

    public void ReloadeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadFirstBoss()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadFinalBoss()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadStory()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(5);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadNewGame()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(7);
    }

    public void LoadingScreen()
    {
        SceneManager.LoadScene(8);
    }

    public void FinalScene()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(9);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
