using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementClean : MonoBehaviour
{
    Rigidbody rigidBody;
    // by adding SerializeField I expose these fields to Unity - now they show in the script component in the UI
    [SerializeField] float stepDistance = 5f;
    [SerializeField] float jumpDistance = 5f;
    [SerializeField] AudioSource jumpSound;
    float touchingGroundDistanceValue = .1f;



    // transform contains the position of an object
    // after declaring it as a SerializeField => it shows up as a field in Unity - script component in player
    // still need to chose what the 'transform' I'm interested in is, in the UI
    [SerializeField] Transform groundCheck;
    // layer manually added to the floor prefab
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        // get the rigid body here
        this.rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // values are taken from InputManager
        // they can return a value in [-1, 1] interval - this also takes joystick input - allows slow movement 
        // Difference between GetAxis and GetAxisRaw -> GetAxis smooths the velocity going back to 0.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        this.rigidBody.velocity = new Vector3(horizontalInput * this.stepDistance, this.rigidBody.velocity.y, verticalInput * this.stepDistance);

        if (Input.GetButtonDown("Jump") && isTouchingGround())
        {
            Jump();
        }
    }

    private void Jump()
    {
        this.rigidBody.velocity = new Vector3(this.rigidBody.velocity.x, this.jumpDistance, this.rigidBody.velocity.z);
        jumpSound.Play();
    }

    bool isTouchingGround()
    {
        // first arg - position
        // second arg - distance between object and ground for which I consider the object to be grounded
        // third arg - layer mask - need to add layer to the other object - in this case the floor prefab
        return Physics.CheckSphere(this.groundCheck.position, this.touchingGroundDistanceValue, this.ground);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy Head"))
        {
            // destroy the whole enemy - the parent with its children
            Destroy(other.transform.parent.gameObject);
            Jump();
        }
    }
}
