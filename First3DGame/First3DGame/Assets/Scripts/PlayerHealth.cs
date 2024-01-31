using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    float yDeathPoint = -2;
    bool isDead = false;
    [SerializeField] AudioSource deadByCollisionSound;
    [SerializeField] AudioSource deadByFallingSound;
    private void Update()
    {
        if (transform.position.y < this.yDeathPoint && !this.isDead)
        {
            deadByFallingSound.Play();
            Die();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        // either compare name or tag. different use cases
        if (other.gameObject.CompareTag("Enemy"))
        {
            // disable mesh => make it invisible
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovementClean>().enabled = false;
            deadByCollisionSound.Play();
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Oops dead");
        // this will wait for a specified duration before calling the method
        Invoke(nameof(Reload), 1.3f);
        // Reload();
        this.isDead = true;
    }


    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
