using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizMaster3 : MonoBehaviour
{
    [SerializeField] GameObject extraTimeCanvas;
    [SerializeField] GameObject timePenaltyCanvas;

    bool vanish = false;

    public static QuizMaster3 quizMaster3;
    // Start is called before the first frame update
    void Start()
    {
        quizMaster3 = this;
    }

    private void FixedUpdate()
    {
        extraTimeCanvas.transform.rotation = Camera.main.transform.rotation;
        timePenaltyCanvas.transform.rotation = Camera.main.transform.rotation;

        StartCoroutine("Vanish");
    }

    public void RightAnswer3()
    {
        extraTimeCanvas.SetActive(true);
        vanish = true;
    }
    public void WrongAnswer3()
    {
        timePenaltyCanvas.SetActive(true);
        vanish = true;
    }

    IEnumerator Vanish()
    {
        while (vanish == true)
        {
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
            yield return new WaitForSeconds(3f);
        }
    }
}
