using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton2 : MonoBehaviour
{
    [SerializeField] Transform button;
    [SerializeField] Color pushedColor;
    [SerializeField] GameObject wall;

    float pushed = -0.12f;
    float posX, posY;

    private void Start()
    {
        posX = transform.localPosition.x;
        posY = transform.localPosition.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spell")
        {
            transform.localPosition = new Vector3(posX, posY, pushed);
            button.GetComponent<Renderer>().material.color = pushedColor;
            wall.SendMessage("StartAnim");
        }
    }
}
