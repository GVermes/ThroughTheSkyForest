using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float gameTime;
    [SerializeField] Text gameTimeText;
    [SerializeField] GameObject quizQuestion;
    [SerializeField] GameObject quizQuestion2;
    [SerializeField] GameObject quizQuestion3;
    [SerializeField] LevelManager lm;
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] [Range(0, 1)] float gameOverSFXVolume = 1f;

    public static TimeManager timeManager;


    // Start is called before the first frame update
    private void Start()
    {
        timeManager = this;
        StartCoroutine("GameTimeManager");
    }

    IEnumerator GameTimeManager()
    {
        while (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            gameTimeText.text = gameTime.ToString("F0");

            if (gameTime <= 10)
            {
                gameTimeText.color = Color.red;
            }
            if (gameTime >= 10)
            {
                gameTimeText.color = Color.yellow;
            }
            yield return null;
        }
        if (gameTime <= 0)
        {
            AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position, gameOverSFXVolume);
            yield return new WaitForSeconds(1f);
            lm.ReloadeLevel();
        }
    }

    public void EnemyExtraTime()
    {
        gameTime += 20;
    }
    public void ExtraTime()
    {
        QuizMaster.quizMaster.SendMessage("RightAnswer");
        gameTime += 20;
        quizQuestion.SetActive(false);
    }

    public void ExtraTime2()
    {
        QuizMaster2.quizMaster2.SendMessage("RightAnswer2");
        gameTime += 20;
        quizQuestion2.SetActive(false);
    }

    public void ExtraTime3()
    {
        QuizMaster3.quizMaster3.SendMessage("RightAnswer3");
        gameTime += 20;
        quizQuestion3.SetActive(false);
    }

    public void WrongButton()
    {
        gameTime -= 5;
    }

    public void WaterTimePenalty()
    {
        gameTime -= 5;
    }

    public void EnemyTimePenalty()
    {
        gameTime -= 5;
    }

    public void TimePenalty()
    {
        QuizMaster.quizMaster.SendMessage("WrongAnswer");
        gameTime -= 5;
        quizQuestion.SetActive(false);
    }

    public void TimePenalty2()
    {
        QuizMaster2.quizMaster2.SendMessage("WrongAnswer2");
        gameTime -= 5;
        quizQuestion2.SetActive(false);
    }
    public void TimePenalty3()
    {
        QuizMaster3.quizMaster3.SendMessage("WrongAnswer3");
        gameTime -= 5;
        quizQuestion3.SetActive(false);
    }
}
