using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject endText;
    [SerializeField] AudioClip gotHitSFX;
    [SerializeField] [Range(0, 1)] float gotHitSFXVolume = 0.5f;
    [SerializeField] LevelManager lm;
    [SerializeField] AudioClip winSFX;
    [SerializeField] [Range(0, 1)] float winSFXVolume = 0.5f;

    Animator anim;

    public static Boss boss;

    private void Awake()
    {
        boss = this;
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);

        if(transform.position.x >= 20f)
        {
            speed = -1 * speed;
        }
        if(transform.position.x <= -20f)
        {
            speed = -1 * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spell")
        {
            AudioSource.PlayClipAtPoint(gotHitSFX, Camera.main.transform.position, gotHitSFXVolume);
            anim.SetBool("gotHit", true);
        }
        else
        {
            anim.SetBool("gotHit", false);
        }
    }

    public IEnumerator Die()
    {
        yield return null;
        AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position, winSFXVolume);
        endText.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        anim.SetBool("die", true);
        yield return new WaitForSeconds(2.2f);
        lm.LoadLevel2();
    }
}
