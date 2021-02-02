using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBossButton5 : MonoBehaviour
{
    [SerializeField] Transform button;
    [SerializeField] Color pushedColor;
    [SerializeField] AudioClip rightAnswerSFX;
    [SerializeField] [Range(0, 1)] float rightAnswerSFXVolume = 0.5f;

    float pushed = -0.15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" || other.tag == "Player2")
        {
            AudioSource.PlayClipAtPoint(rightAnswerSFX, Camera.main.transform.position, rightAnswerSFXVolume);
            transform.localPosition = new Vector3(0, pushed, 0);
            button.GetComponent<Renderer>().material.color = pushedColor;
            BossCanvas.bc.SendMessage("Next5");
            FinalBoss.boss.SendMessage("Die");
        }
    }
}
