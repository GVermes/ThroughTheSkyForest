using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{                               
    [SerializeField] GameObject quizCanvas;
    [SerializeField] GameObject interactionText;
    [SerializeField] AudioClip meowSFX;
    [SerializeField] [Range(0, 1)] float meowSFXVolume = 0.5f;

    bool gameIsPaused = false;
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && interactionText.active == true && !gameIsPaused)
        {        
            Pause();
        }
        else if (gameIsPaused == true && quizCanvas.active == false)
        {
            Resume();
        }
      
    }

    void Pause()
    {
        AudioSource.PlayClipAtPoint(meowSFX, Camera.main.transform.position, meowSFXVolume);
        Player1.player1.SendMessage("QuizOn");
        Cursor.visible = true;
        interactionText.SetActive(false);
        quizCanvas.SetActive(true);
        Time.timeScale = 0.3f;
        gameIsPaused = true;
    }

    void Resume()
    {
        Player1.player1.SendMessage("QuizOff");
        Cursor.visible = false;
        quizCanvas.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
