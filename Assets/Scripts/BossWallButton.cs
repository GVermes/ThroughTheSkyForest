using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWallButton : MonoBehaviour
{
    [SerializeField] Transform button;
    [SerializeField] Color pushedColor;
    [SerializeField] Color startColor;

    float pushed = 0.33f;
    float posZ, posY, posX;

    public static BossWallButton instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        posZ = transform.localPosition.z;
        posY = transform.localPosition.y;
        posX = transform.localPosition.x;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spell")
        {
            transform.localPosition = new Vector3(pushed, posY, posZ);
            button.GetComponent<Renderer>().material.color = pushedColor;
            BossObstacle.instace.SendMessage("PlayAnimation");
        }
    }

    public void Off()
    {
        transform.localPosition = new Vector3(posX, posY, posZ);
        button.GetComponent<Renderer>().material.color = startColor;
    }
}
