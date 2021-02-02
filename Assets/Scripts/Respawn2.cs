using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn2 : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] AudioClip waterSFX;
    [SerializeField] [Range(0, 1)] float waterSFXVolume = 0.5f;

    public static Respawn2 respawn2;

    // Start is called before the first frame update
    void Start()
    {
        respawn2 = this;
    }

    public void RespawnLocation2()
    {
        AudioSource.PlayClipAtPoint(waterSFX, Camera.main.transform.position, waterSFXVolume);
        player1.transform.position = transform.position - new Vector3(1, 0, 0);
        player2.transform.position = transform.position + new Vector3(1, 0, 0);
    }
}
