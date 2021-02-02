using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    public static Respawn respawn;

    // Start is called before the first frame update
    void Start()
    {
        respawn = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1" || other.tag == "Player2")
        {
            //new checkpoint respawn location
        }
    }

    public void RespawnLocation()
    {
        player1.transform.position = transform.position - new Vector3(1,0,0);
        player2.transform.position = transform.position + new Vector3(1,0,0);
    }
}
