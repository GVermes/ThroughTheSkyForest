using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door door;
    // Start is called before the first frame update
    void Start()
    {
        door = this;
    }

    public void RightButton()
    {
        gameObject.SetActive(false);
    }
   
}
