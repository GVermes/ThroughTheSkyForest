using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongButton : MonoBehaviour
{
    [SerializeField] Transform button;
    [SerializeField] Color pushedColor;
    [SerializeField] AudioClip wrongAnswerSFX;
    [SerializeField] [Range(0, 1)] float wrongAnswerSFXVolume = 0.5f;

    float pushed = -0.55f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" || other.tag == "Player2")
        {
            AudioSource.PlayClipAtPoint(wrongAnswerSFX, Camera.main.transform.position, wrongAnswerSFXVolume);
            transform.localPosition = new Vector3(0, pushed, 0);
            button.GetComponent<Renderer>().material.color = pushedColor;
            TimeManager.timeManager.SendMessage("WrongButton");
        }
    }
}
