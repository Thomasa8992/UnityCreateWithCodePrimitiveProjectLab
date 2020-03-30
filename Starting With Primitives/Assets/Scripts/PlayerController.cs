using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10;

    private Rigidbody playerRigidBody;
    public float jumpForce = 15;
    public float gravityModifier = 1;
    public bool isOnGround;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime * horizontalInput);

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
    }
}
