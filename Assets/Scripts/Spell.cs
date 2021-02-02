using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] float spellSpeed;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, spellSpeed) * Time.deltaTime);
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
