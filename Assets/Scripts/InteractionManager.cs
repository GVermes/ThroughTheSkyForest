using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] GameObject interactionText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1")
        {
            interactionText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactionText.SetActive(false);
    }
}
