using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    int collectibleCount = 0;
    [SerializeField] AudioSource collectSound;

    [SerializeField] TextMeshProUGUI collectibleCountText;

    // // This doesn't work anymore if isTrigger is selected
    // private void OnCollisionEnter(Collision other) {

    // }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            collectSound.Play();
            this.collectibleCount++;
            Debug.Log(this.collectibleCount);
            this.collectibleCountText.text = "Collected: " + this.collectibleCount;
        }
    }
}
