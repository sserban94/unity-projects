using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Player")
        {
            // this sets a parent for the player - in this case transform is the floor. This floor is now the parent of Player
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
