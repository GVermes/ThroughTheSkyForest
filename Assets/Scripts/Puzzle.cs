using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{

    float risePos = 2.5f;
    float startPosY;

    public static Puzzle puzzle;

    private void Awake()
    {
        puzzle = this;
    }

    private void Start()
    {
        startPosY = transform.position.y;
    }
    public void Rise()
    {
        transform.localScale = new Vector3(transform.localScale.x, risePos, transform.localScale.z);
    }

    public void FallBack()
    {
        transform.localScale = new Vector3(transform.localScale.x, startPosY, transform.localScale.z);
    }
}
