using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLvl1 : MonoBehaviour
{
    [SerializeField] GameObject[] fireWorks;
    [SerializeField] LevelManager lm;
    [SerializeField] AudioClip goalSFX;
    [SerializeField] [Range(0, 1)] float goalSFXVolume = 0.6f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" || other.tag == "Player2")
        {
            for (int i = 0; i < fireWorks.Length; i++)
            {
                AudioSource.PlayClipAtPoint(goalSFX, Camera.main.transform.position, goalSFXVolume);
                fireWorks[i].SetActive(true);
                Invoke("LoadNextScene", 2f);
            }
        }
    }

    public void LoadNextScene()
    {
        lm.LoadFirstBoss();
    }
}
