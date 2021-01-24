using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAction { Standing, Crouching, Walking, Running, CrouchMovement, Climbing };

public class PlayerMovement : MonoBehaviour {

    private CharacterController cc;

    private const float GRAVITY_VALUE = -9.8f;

    public PlayerAction playerAction;

    public float walkSpeed = 2f;
    public float runningSpeed = 5f;
    public float crouchRunningSpeed = 1f;
    public float climbingSpeed;
    public float jumpHeight = 1.0f;

    public Vector3 moveDirection;



    private float playerYVelocity;

    private bool runningInput = false;
    private bool crouchingInput = false;

    private void Start() {
        cc = GetComponent<CharacterController>();
        playerAction = PlayerAction.Standing;
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            runningInput = !runningInput;
            crouchingInput = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            crouchingInput = !crouchingInput;
            runningInput = false;
        }

        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveDirection += transform.right;
        }

        float speed = 0;
        
        if (moveDirection == Vector3.zero) {
            if (crouchingInput) {
                playerAction = PlayerAction.Crouching;
            }
            else {
                playerAction = PlayerAction.Standing;
            }
        }
        else {
            if (runningInput) {
                playerAction = PlayerAction.Running;
                speed = runningSpeed;
            }
            else if (crouchingInput) {
                playerAction = PlayerAction.CrouchMovement;
                speed = crouchRunningSpeed;
            }
            else {
                playerAction = PlayerAction.Walking;
                speed = walkSpeed;
            }
        }

        cc.Move(moveDirection.normalized * speed * Time.deltaTime);
        

        bool grounded = IsGrounded();
        // print(grounded);

        if (grounded && playerYVelocity < 0) {
            playerYVelocity = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && grounded) {
            playerYVelocity += Mathf.Sqrt(jumpHeight * -3.0f * GRAVITY_VALUE);
            playerYVelocity = Mathf.Clamp(playerYVelocity, 0, 5f);
        }

        playerYVelocity += GRAVITY_VALUE * Time.deltaTime;
        cc.Move(new Vector3(0, playerYVelocity * Time.deltaTime, 0));
    }

    private bool IsGrounded() {
        float maxDistance = 0.6f;
        RaycastHit hit;
        return Physics.BoxCast(transform.position, transform.lossyScale / 2, Vector3.down, out hit, transform.rotation, maxDistance);
    }

    //private void OnDrawGizmos() {
    //    float maxDistance = 0.6f;
    //    RaycastHit hit;
    //    bool isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2, Vector3.down, out hit, transform.rotation, maxDistance);

    //    if (isHit) {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawWireCube(transform.position + Vector3.down * hit.distance, transform.lossyScale);
    //    }
    //}

}


