using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLvl2 : MonoBehaviour
{
    float fallPos = -3.04f;
    float startPosY;

    public static DoorLvl2 instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startPosY = transform.position.y;
    }
    public void FallDown()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, fallPos, transform.localPosition.z);
    }

    public void BackUp()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, startPosY, transform.localPosition.z);
    }
}
