// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     Rigidbody rigidBody;

//     // Start is called before the first frame update
//     void Start()
//     {
//         // get the rigid body here
//         rigidBody = GetComponent<Rigidbody>();

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // // GetKeyDown only works on the press
//         // if (Input.GetKeyDown("space"))
//         // {
//         //     // GetComponent is a method from the Component class
//         //     // it actually is a method which returns a generic type T and also accepts T as arg
//         //     // y is 5
//         //     // rigidBody.velocity = new Vector3(0, 5, 0);
//         //     // in order to avoid movement brakes when I jump
//         //     // instead of keep the x velocity 0
//         //     // I should save the previous velocity 
//         //     rigidBody.velocity = new Vector3(rigidBody.velocity.x, 5, rigidBody.velocity.z);
//         // }
//         // GetButtonDown works with the Input Manager in Unity
//         if (Input.GetButtonDown("Jump"))
//         {
//             rigidBody.velocity = new Vector3(rigidBody.velocity.x, 5, rigidBody.velocity.z);
//         }


//         if (Input.GetKey("up"))
//         {
//             // the same(above) applies here - in order to let the player fall after jumping
//             // I should use the previous y velocity
//             // rigidBody.velocity = new Vector3(0, 0, 5);
//             rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, 5);
//         }
//         if (Input.GetKey("down"))
//         {
//             // rigidBody.velocity = new Vector3(0, 0, -5);
//             rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -5);
//         }
        
//         if (Input.GetKey("right"))
//         {
//             // rigidBody.velocity = new Vector3(5, 0, 0);
//             rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, rigidBody.velocity.z);
//         }
//         if (Input.GetKey("left"))
//         {
//             // rigidBody.velocity = new Vector3(-5, 0, 0);
//             rigidBody.velocity = new Vector3(-5, rigidBody.velocity.y, rigidBody.velocity.z);
//         }
//     }
// }
