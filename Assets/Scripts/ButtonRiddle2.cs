﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRiddle2 : MonoBehaviour
{
    [SerializeField] Transform button;
    [SerializeField] Color pushedColor;
    [SerializeField] Color notPushedColor;
    [SerializeField] GameObject wall;
    [SerializeField] AudioClip puzzleSFX;
    [SerializeField] [Range(0, 1)] float puzzleSFXVolume = 0.9f;


    float pushed = -0.55f;
    float notPushed = 2.4f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "puzzle")
        {
            AudioSource.PlayClipAtPoint(puzzleSFX, Camera.main.transform.position, puzzleSFXVolume);
            transform.localPosition = new Vector3(0, pushed, 0);
            button.GetComponent<Renderer>().material.color = pushedColor;
            wall.SendMessage("TwoDone", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.localPosition = new Vector3(0, notPushed, 0);
        button.GetComponent<Renderer>().material.color = notPushedColor;
        wall.SendMessage("TwoDone", false);
    }
}
