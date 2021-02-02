using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButtonManager : MonoBehaviour
{
    [SerializeField] GameObject[] buttons1;
    [SerializeField] GameObject[] buttons2;
    [SerializeField] GameObject[] buttons3;
    [SerializeField] GameObject[] buttons4;
    [SerializeField] GameObject[] buttons5;
    [SerializeField] GameObject shootText;

    public static BossButtonManager bbm;

    private void Start()
    {
        bbm = this;
    }

    public void NextQuestion()
    {
        StartCoroutine("NQ");
    }

    IEnumerator NQ()
    {
        shootText.SetActive(true);
        yield return new WaitForSeconds(2f);
        shootText.SetActive(false);
        for (int i = 0; i <= 1; i++)
        {
            Destroy(buttons1[i]);
        }
        yield return new WaitForSeconds(0.5f);
        for (int a = 0; a <= 1; a++)
        {
            buttons2[a].SetActive(true);
        }
    }

    public void NextQuestion2()
    {
        StartCoroutine("NQ2");
    }

    IEnumerator NQ2()
    {
        shootText.SetActive(true);
        yield return new WaitForSeconds(2f);
        shootText.SetActive(false);
        for (int i = 0; i <= 1; i++)
        {
            Destroy(buttons2[i]);
        }
        yield return new WaitForSeconds(0.5f);
        for (int a = 0; a <= 1; a++)
        {
            buttons3[a].SetActive(true);
        }
    }

    public void NextQuestion3()
    {
        StartCoroutine("NQ3");
    }

    IEnumerator NQ3()
    {
        shootText.SetActive(true);
        yield return new WaitForSeconds(2f);
        shootText.SetActive(false);
        for (int i = 0; i <= 1; i++)
        {
            Destroy(buttons3[i]);
        }
        yield return new WaitForSeconds(0.5f);
        for (int a = 0; a <= 1; a++)
        {
            buttons4[a].SetActive(true);
        }
    }

    public void NextQuestion4()
    {
        StartCoroutine("NQ4");
    }

    IEnumerator NQ4()
    {
        shootText.SetActive(true);
        yield return new WaitForSeconds(2f);
        shootText.SetActive(false);
        for (int i = 0; i <= 1; i++)
        {
            Destroy(buttons4[i]);
        }
        yield return new WaitForSeconds(0.5f);
        for (int a = 0; a <= 1; a++)
        {
            buttons5[a].SetActive(true);
        }
    }
}
