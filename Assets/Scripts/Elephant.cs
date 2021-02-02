using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elephant : MonoBehaviour
{
    [SerializeField] GameObject eli;
    [SerializeField] GameObject eText;
    [SerializeField] Animator anim;
    [SerializeField] AudioClip elephantSFX;
    [SerializeField] [Range(0, 1)] float elephantSFXVolume = 0.6f;

    bool isMoving = false;

    public static Elephant instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (eText.active == true && Input.GetKeyDown(KeyCode.F))
        {
            eText.SetActive(false);
            MoveEli.instance.SendMessage("PleaseMove");
        }

        if(isMoving == true)
        {
            eli.transform.Translate(new Vector3(0, 0, 10) * Time.deltaTime);
            Destroy(eli, 6f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1")
        {
            eText.SetActive(true);
        }
    }

    public void MoveAnim()
    {
        AudioSource.PlayClipAtPoint(elephantSFX, Camera.main.transform.position, elephantSFXVolume);
        anim.SetBool("move", true);
        isMoving = true;
    }
}
