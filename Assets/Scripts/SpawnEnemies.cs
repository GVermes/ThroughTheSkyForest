using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            for(int i = 0; i <= 10; i++)
            {
                enemy[i].SetActive(true);
                yield return new WaitForSeconds(7f);
            } 
        }
    }
}
