using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton3 : MonoBehaviour
{
    [SerializeField] Transform button;
    [SerializeField] Color pushedColor;
    [SerializeField] Color enabledColor;
    [SerializeField] GameObject obstacle;
    [SerializeField] AudioClip puzzleSFX;
    [SerializeField] [Range(0, 1)] float puzzleSFXVolume = 1f;

    float pushed = -0.12f;
    float posX, posY;
    bool canBeUsed = false;

    private void Start()
    {
        posX = transform.localPosition.x;
        posY = transform.localPosition.y;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spell" && canBeUsed == true)
        {
            AudioSource.PlayClipAtPoint(puzzleSFX, Camera.main.transform.position, puzzleSFXVolume);
            transform.localPosition = new Vector3(posX, posY, pushed);
            button.GetComponent<Renderer>().material.color = pushedColor;
            obstacle.SendMessage("Solved");
        }
    }

    public void CanBeUsed()
    {
        canBeUsed = true;
        button.GetComponent<Renderer>().material.color = enabledColor;
    }
}
