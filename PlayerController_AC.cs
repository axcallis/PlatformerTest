using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_AC : MonoBehaviour
{
    public static PlayerController_AC controllerInstance;

    public Camera cam;
    public Transform player;
    public float moveForce;
    public float jumpForce;
    public float camForce;

    bool jumpReady = true;
    Vector3 playerVelocity;
    public bool grounded;
    [HideInInspector]
    public bool rightFacing = true;
    public bool disableJump;
    CharacterController controller;

    private void Awake() => controllerInstance = this;

    void Start() => controller = player.GetComponent<CharacterController>();

    private void Update()
    {
        grounded = controller.isGrounded;
        if (Input.GetButtonDown("Jump") && !disableJump)
            playerVelocity.y += jumpForce;

        if (Input.GetButtonDown("Fire1"))
            ProjectileLoader_AC.projLoaderInstance.LoadProjectile();

        if (grounded && playerVelocity.y < 0)
            playerVelocity.y = 0;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * moveForce);

        if (move != Vector3.zero)
            transform.forward = move;

        playerVelocity.y += -9.81f * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}