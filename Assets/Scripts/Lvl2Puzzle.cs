using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2Puzzle : MonoBehaviour
{
    [SerializeField] GameObject riddle;
    [SerializeField] GameObject puzzle;

    Animator anim;
    bool pushed1 = false;
    bool pushed2 = false;

    public Lvl2Puzzle instance;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (pushed1 && pushed2)
        {
            Destroy(puzzle);
        }
    }

    public void StartAnim()
    {
        riddle.SetActive(false);
        anim.SetBool("start", true);
    }

    public void OneDone(bool ready)
    {
        if (ready)
        {
            pushed1 = true;
        }
        if (!ready)
        {
            pushed1 = false;
        }
    }

    public void TwoDone(bool on)
    {
        if (on)
        {
            pushed2 = true;
        }
        if (!on)
        {
            pushed2 = false;
        }
    }
}
