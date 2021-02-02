using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizMaster2 : MonoBehaviour
{
    [SerializeField] GameObject extraTimeCanvas;
    [SerializeField] GameObject timePenaltyCanvas;

    bool vanish = false;

    public static QuizMaster2 quizMaster2;
    // Start is called before the first frame update
    void Start()
    {
        quizMaster2 = this;
    }

    private void FixedUpdate()
    {
        extraTimeCanvas.transform.rotation = Camera.main.transform.rotation;
        timePenaltyCanvas.transform.rotation = Camera.main.transform.rotation;

        StartCoroutine("Vanish");
    }

    public void RightAnswer2()
    {
        extraTimeCanvas.SetActive(true);
        vanish = true;
    }
    public void WrongAnswer2()
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
