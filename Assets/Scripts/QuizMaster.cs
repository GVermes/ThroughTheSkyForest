using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizMaster : MonoBehaviour
{
    [SerializeField] GameObject extraTimeCanvas;
    [SerializeField] GameObject timePenaltyCanvas;

    bool vanish = false;

    public static QuizMaster quizMaster;
    // Start is called before the first frame update
    void Start()
    {
        quizMaster = this;
    }

    private void FixedUpdate()
    {
        extraTimeCanvas.transform.rotation = Camera.main.transform.rotation;
        timePenaltyCanvas.transform.rotation = Camera.main.transform.rotation;

        StartCoroutine("Vanish");
    }

    public void RightAnswer()
    {
        extraTimeCanvas.SetActive(true);
        vanish = true;
    }

    public void WrongAnswer()
    {
        timePenaltyCanvas.SetActive(true);
        vanish = true;
    }

    IEnumerator Vanish()
    {
        while (vanish)
        {
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
            yield return new WaitForSeconds(3f);
        }
    }
}
