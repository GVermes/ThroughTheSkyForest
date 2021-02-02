using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] GameObject waterPenaltyText;
    [SerializeField] AudioClip waterSFX;
    [SerializeField] [Range(0, 1)] float waterSFXVolume = 0.5f;
    [SerializeField] MeshCollider mesh;

    public static Water water;

    private void Start()
    {
        water = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1" || other.tag == "Player2")
        {
            Respawn.respawn.SendMessage("RespawnLocation");
            Player1.player1.SendMessage("Die");
            Player2.player2.SendMessage("Die");
            AudioSource.PlayClipAtPoint(waterSFX, Camera.main.transform.position, waterSFXVolume);
            TimeManager.timeManager.SendMessage("WaterTimePenalty");
            StartCoroutine("WaterPenalty");
        }
    }

    IEnumerator WaterPenalty()
    {
        yield return null;
        waterPenaltyText.SetActive(true);
        yield return new WaitForSeconds(1f);
        waterPenaltyText.SetActive(false);

    }

    public void ButtonPushed()
    {
        mesh.enabled = false;
    }
}
