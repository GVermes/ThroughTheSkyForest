using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Transform lookAtCube;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject spell;
    [SerializeField] GameObject spellSpawnLocation;
    [SerializeField] AudioClip carrotSpellSFX;
    [SerializeField] [Range(0, 1)] float carrotSpellSFXVolume = 0.5f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] SkinnedMeshRenderer mesh;

    Rigidbody rigi;
    RaycastHit hitObject;
    bool grounded;

    public static Player2 player2;

    // Start is called before the first frame update
    void Start()
    {
        player2 = this;
        rigi = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            Movement();
        }
        Gravity();
        OutOfMap();
    }

    void Gravity()
    {
        if (Physics.Raycast(transform.position, -transform.up, out hitObject, 1.02f, groundLayer))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
            rigi.velocity -= new Vector3(0, 0.1f, 0);
        }
}

    void Movement()
    {
        lookAtCube.localPosition = new Vector3(rigi.velocity.x, -1, rigi.velocity.z);
        anim.transform.LookAt(lookAtCube);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigi.velocity = new Vector3(0, 0, moveSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigi.velocity = new Vector3(0, 0, -moveSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigi.velocity = new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigi.velocity = new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(1))
        {
            AudioSource.PlayClipAtPoint(carrotSpellSFX, Camera.main.transform.position, carrotSpellSFXVolume);
            Instantiate(spell, spellSpawnLocation.transform.position, spellSpawnLocation.transform.rotation);
        }
        
        anim.SetFloat("moveSpeed", rigi.velocity.magnitude);
    }

    public void Die()
    {
        StartCoroutine("Death");
    }

    IEnumerator Death()
    {
        yield return null;
        mesh.enabled = false;
        yield return new WaitForSeconds(1f);
        mesh.enabled = true;
        yield return new WaitForSeconds(0.3f);
        mesh.enabled = false;
        yield return new WaitForSeconds(0.3f);
        mesh.enabled = true;
        yield return new WaitForSeconds(0.3f);
        mesh.enabled = false;
        yield return new WaitForSeconds(0.3f);
        mesh.enabled = true;
    }

    public void OutOfMap()
    {
        if (transform.position.y <= -3)
        {
            Respawn2.respawn2.SendMessage("RespawnLocation2");
            StartCoroutine("Death");
        }
    }
}
