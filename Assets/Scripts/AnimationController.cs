using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField] AudioClip footStepSFX;
    [SerializeField] [Range(0, 1)] float footStepSFXVolume = 0.5f;
    
    public void FootStep()
    {
        AudioSource.PlayClipAtPoint(footStepSFX, Camera.main.transform.position, footStepSFXVolume);
    }
}
