using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Transform lookAtCube;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] [Range(0, 1)] float jumpSFXVolume = 0.5f;
    [SerializeField] SkinnedMeshRenderer mesh;

    float hori, verti;
    Vector3 movement;
    float currentPos;
    Rigidbody rigi;
    bool canJump = true;
    RaycastHit hitObject;
    bool grounded;
    Vector3 greetingsPos = new Vector3(0, 10f, 0);

    public static Player1 player1;
    
    // Start is called before the first frame update
    void Start()
    {
        player1 = this;
        rigi = GetComponent<Rigidbody>();
        anim.transform.LookAt(Camera.main.transform.position - greetingsPos);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Gravity();
        OutOfMap();
    }

    void Movement()
    {
        hori = Input.GetAxis("Horizontal");
        verti = Input.GetAxis("Vertical");

        lookAtCube.localPosition = new Vector3(hori, -1, verti);
        anim.transform.LookAt(lookAtCube);

        movement.z = verti * moveSpeed;
        movement.x = hori * moveSpeed;
        
        movement = transform.TransformDirection(movement);

        rigi.velocity = movement * Time.deltaTime;
        anim.SetFloat("moveSpeed", movement.magnitude);

    }

    void Jump()
    {
        if (canJump && grounded && Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position, jumpSFXVolume);
            anim.SetBool("isJump", true);
            rigi.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Gravity()
    {
        if (Physics.Raycast(transform.position, -transform.up, out hitObject, 1.02f, groundLayer))
        {
            grounded = true;
            movement.y = 0;
            anim.SetBool("isJump", false);
        }
        else
        {
            grounded = false;
            movement.y -= 0.2f;
        }
    }

    public void QuizOn()
    {
        canJump = false;
    }

    public void QuizOff()
    {
        canJump = true;
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
        if(transform.position.y <= -3)
        {
            Respawn2.respawn2.SendMessage("RespawnLocation2");
            StartCoroutine("Death");
        }
    }
}
