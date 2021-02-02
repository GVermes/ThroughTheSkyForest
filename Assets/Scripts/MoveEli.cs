using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEli : MonoBehaviour
{
    [SerializeField] GameObject askText;

    public static MoveEli instance;

    private void Awake()
    {
        instance = this;
    }
    
    public IEnumerator PleaseMove()
    {
        yield return null;
        askText.SetActive(true);
        yield return new WaitForSeconds(2f);
        askText.SetActive(false);
        Elephant.instance.SendMessage("MoveAnim");
    }
}
