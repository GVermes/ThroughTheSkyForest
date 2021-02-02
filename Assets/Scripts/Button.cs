using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Transform button;
    [SerializeField] Color pushedColor;
    [SerializeField] AudioClip puzzleSFX;
    [SerializeField] [Range(0, 1)] float puzzleSFXVolume = 0.9f;

    float pushed = -0.55f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            AudioSource.PlayClipAtPoint(puzzleSFX, Camera.main.transform.position, puzzleSFXVolume);
            transform.localPosition = new Vector3(0, pushed, 0);
            button.GetComponent<Renderer>().material.color = pushedColor;
            Water.water.SendMessage("ButtonPushed");
            Bridge.bridge.SendMessage("PlayAnim");
        }
    }
}
