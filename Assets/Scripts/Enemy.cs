using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform target;
    [SerializeField] float range;
    [SerializeField] Animator anim;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject dieVFX;
    [SerializeField] float deathDuration = 1f;
    [SerializeField] AudioClip deadSFX;
    [SerializeField] [Range(0, 1)] float deadSFXVolume = 0.5f;
    [SerializeField] GameObject extraTimeCanvas;
    [SerializeField] GameObject timePenaltyCanvas;

    Rigidbody rigi;
    Collider col;

    public static Transform targeted;
    public static Enemy enemy;

    private void Awake()
    {
        enemy = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        agent.speed = moveSpeed * Time.deltaTime;
        agent.stoppingDistance = 0;

        while (Vector3.Distance(transform.position, target.position) <= range)
        {
            transform.LookAt(target.position);
            yield return new WaitForSeconds(0.5f);
            agent.SetDestination(GameObject.FindWithTag("Player1").transform.position);
            anim.SetFloat("moveSpeed", agent.velocity.magnitude);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
        {
            timePenaltyCanvas.SetActive(true);
            AudioSource.PlayClipAtPoint(deadSFX, Camera.main.transform.position, deadSFXVolume);
            GameObject deadVFX = Instantiate(dieVFX, transform.position, transform.rotation);
            Destroy(deadVFX, deathDuration);
            col.enabled = false;
            TimeManager.timeManager.SendMessage("EnemyTimePenalty");
            Camera.main.SendMessage("Shake");
            anim.SetBool("isDead", true);
            Destroy(gameObject, 0.8f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spell")
        {
            extraTimeCanvas.SetActive(true);
            AudioSource.PlayClipAtPoint(deadSFX, Camera.main.transform.position, deadSFXVolume);
            GameObject deadVFX = Instantiate(dieVFX, transform.position, transform.rotation);
            Destroy(deadVFX, deathDuration);
            col.enabled = false;
            Camera.main.SendMessage("Shake");
            TimeManager.timeManager.SendMessage("EnemyExtraTime");
            anim.SetBool("isDead", true);
            Destroy(gameObject, 0.8f);
        }
    }
}
