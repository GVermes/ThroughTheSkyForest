using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] Animator anim;

    public static Bridge bridge;

    private void Start()
    {
        bridge = this;
    }

    public void PlayAnim()
    {
        anim.SetBool("isPushed", true);
    }
}
