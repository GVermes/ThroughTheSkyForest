using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge2 : MonoBehaviour
{
    [SerializeField] GameObject bridge;
    
    public static Bridge2 bridge2;

    bool pushed1 = false;
    bool pushed2 = false;
    // Start is called before the first frame update
    void Start()
    {
        bridge2 = this;
    }

    private void Update()
    {
        if(pushed1 && pushed2)
        {
            bridge.SetActive(true);
        }
    }

    public void One()
    {
        pushed1 = true; 
    }

    public void Two()
    {
        pushed2 = true;
    }
}
