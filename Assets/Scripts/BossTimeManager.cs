using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTimeManager : MonoBehaviour
{
    [SerializeField] float gameTime;
    [SerializeField] Text gameTimeText;
    [SerializeField] LevelManager lm;
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] [Range(0, 1)] float gameOverSFXVolume = 1f;

    public static BossTimeManager bossTM;

    private void Awake()
    {
        bossTM = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine("BossGameTimeManager");
    }

    IEnumerator BossGameTimeManager()
    {
        while (gameTime >= 0)
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

    public void WrongAnswer()
    {
        gameTime -= 5f;
        gameTimeText.text = gameTime.ToString("0F");
    }

    public void RightAnswer()
    {
        gameTime += 5f;
        gameTimeText.text = gameTime.ToString("0F");
    }
}
