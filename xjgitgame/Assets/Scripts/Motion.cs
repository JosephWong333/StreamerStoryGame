using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public static float lookSpeed = 3;
    public float MoveSpeed = 3;
    private Vector2 rotation = Vector2.zero;
    CharacterController cc;

    public float gravity = -9.81f;
    public Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jumpHeight = 1.25f;
    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = transform.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    public void Move() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        //gravity
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        //ground checker
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move * MoveSpeed * Time.deltaTime);

        //jumping
        if (isGrounded && Input.GetButton("Jump") && canJump) {
            print("sup");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }


    public void Look() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -30f, 30f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }
}
