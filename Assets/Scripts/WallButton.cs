using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    [SerializeField] Transform button;
    [SerializeField] Color pushedColor;
    [SerializeField] GameObject wall;
    [SerializeField] AudioClip puzzleSFX;
    [SerializeField] [Range(0, 1)] float puzzleSFXVolume = 1f;

    float pushed = -0.12f;
    float posX, posY;

    private void Start()
    {
        posX = transform.localPosition.x;
        posY = transform.localPosition.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spell")
        {
            AudioSource.PlayClipAtPoint(puzzleSFX, Camera.main.transform.position, puzzleSFXVolume);
            transform.localPosition = new Vector3(posX, posY, pushed);
            button.GetComponent<Renderer>().material.color = pushedColor;
            wall.SendMessage("StartAnim");
        }
    }
}
