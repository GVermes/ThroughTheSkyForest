using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCanvas : MonoBehaviour
{
    [SerializeField] GameObject[] quizTexts;

    public static BossCanvas bc;

    private void Awake()
    {
        bc = this;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2.5f);
        quizTexts[0].SetActive(true);
    }

    public void Next()
    {
        quizTexts[0].SetActive(false);
        quizTexts[1].SetActive(true);
    }

    public void Next2()
    {
        quizTexts[1].SetActive(false);
        quizTexts[2].SetActive(true);
    }

    public void Next3()
    {
        quizTexts[2].SetActive(false);
        quizTexts[3].SetActive(true);
    }

    public void Next4()
    {
        quizTexts[3].SetActive(false);
        quizTexts[4].SetActive(true);
    }

    public void Next5()
    {
        quizTexts[4].SetActive(false);
        quizTexts[5].SetActive(true);
    }
}
