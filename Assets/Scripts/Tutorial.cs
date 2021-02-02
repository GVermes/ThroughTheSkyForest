using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] text;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject checkPoint;
    [SerializeField] GameObject wrongButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject goal;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.5f);
        text[0].SetActive(true);
        yield return new WaitForSeconds(6f);
        text[0].SetActive(false);
        text[1].SetActive(true);
        yield return new WaitForSeconds(5f);
        text[1].SetActive(false);
        text[2].SetActive(true);
        yield return new WaitForSeconds(4f);
        text[2].SetActive(false);
        text[3].SetActive(true);
        yield return new WaitForSeconds(4f);
        text[3].SetActive(false);
        text[4].SetActive(true);
        yield return new WaitForSeconds(2f);
        text[5].SetActive(true);
        text[6].SetActive(true);
        yield return new WaitForSeconds(6f);
        text[4].SetActive(false);
        text[5].SetActive(false);
        text[6].SetActive(false);
        yield return new WaitForSeconds(1.5f);
        text[7].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        text[7].SetActive(false);
        text[8].SetActive(true);
        yield return new WaitForSeconds(5f);
        text[8].SetActive(false);
        text[9].SetActive(true);
        enemy.SetActive(true);
        yield return new WaitForSeconds(5f);
        text[9].SetActive(false);
        text[10].SetActive(true);
        yield return new WaitForSeconds(2f);
        text[10].SetActive(false);
        text[11].SetActive(true);
        yield return new WaitForSeconds(3f);
        wrongButton.SetActive(true);
        rightButton.SetActive(true);
        text[11].SetActive(false);
        text[12].SetActive(true);
        yield return new WaitForSeconds(6f);
        text[12].SetActive(false);
        text[13].SetActive(true);
        yield return new WaitForSeconds(3f);
        text[13].SetActive(false);
        text[14].SetActive(true);
        checkPoint.SetActive(true);
        yield return new WaitForSeconds(5f);
        text[14].SetActive(false);
        text[15].SetActive(true);
        yield return new WaitForSeconds(5f);
        goal.SetActive(true);
    }

}
