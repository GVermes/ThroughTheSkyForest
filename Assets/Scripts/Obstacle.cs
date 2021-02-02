using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject button;
    [SerializeField] GameObject puzzle;

    bool pushed1 = false;
    bool pushed2 = false;

    private void Update()
    {
        if (pushed1 && pushed2)
        {
            button.SendMessage("CanBeUsed");
        }
    }

    public void OnPlace(bool on)
    {
        if (on)
        {
            pushed1 = true;
        }
        if (!on)
        {
            pushed1 = false;
        }
    }

    public void OnMark(bool on)
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

    public void Solved()
    {
        Destroy(puzzle, 0.5f);
    }
}
