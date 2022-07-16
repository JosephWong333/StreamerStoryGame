using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MotionCar : MonoBehaviour
{
    public static float lookSpeed = 3;
    public float MoveSpeed = 3;
    public float SprintSpeed = 5.25f;
    bool isSprinting = false;
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

    //headbob stuff
    //- camera bob
    public float walkBobSpeed = 14f;
    public float walkBobAmount = 0.05f;
    public float sprintBobSpeed = 18f;
    public float sprintBobAmount = 0.1f;
    float defaultYPos = 0;
    float timer;

    public Vector3 camposog;
    public Vector3 camposr;
    public Vector3 camposl;

    public float CamlerpSpeed = 5f;

    //audio
    public AudioSource walkSound;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = transform.GetComponent<CharacterController>();

        defaultYPos = Camera.main.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Look1();
        Move1();
        Cambob1();
    }

    private void LateUpdate()
    {
        //cam lerp
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {

            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, camposog, Time.deltaTime * CamlerpSpeed);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, camposr, Time.deltaTime * CamlerpSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, camposl, Time.deltaTime * CamlerpSpeed);
        }
        else
        {
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, camposog, Time.deltaTime * CamlerpSpeed);
        }
    }

    public void Move1() // Look rotation (UP down is Camera) (Left right is Transform rotation)
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

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) // sprinting checker
        {
            cc.Move(move * SprintSpeed * Time.deltaTime);
        }
        else
        {
            cc.Move(move * MoveSpeed * Time.deltaTime);
        }

        //jumping
        if (isGrounded && Input.GetButton("Jump") && canJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Footstep Sounds
        if (move != Vector3.zero && isGrounded)
        {
            if (walkSound.isPlaying)
            {

            }
            else
            {
                walkSound.Play();
            }

        }
        else
        {
            walkSound.Stop();
        }

    }


    public void Look1() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -30f, 30f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }

    void Cambob1()
    {
        if (!isGrounded) return; //if player jumped then no headbob

        if (Mathf.Abs(cc.velocity.magnitude) > 0)
        {
            timer += Time.deltaTime * (isSprinting ? sprintBobSpeed : !isSprinting ? walkBobSpeed : walkBobSpeed); //good way of cutting down on nested if statements
            Camera.main.transform.localPosition = new Vector3(
                Camera.main.transform.localPosition.x,
                defaultYPos += Time.deltaTime * Mathf.Sin(timer) * (isSprinting ? sprintBobAmount : !isSprinting ? walkBobAmount : walkBobAmount),
                Camera.main.transform.localPosition.z
                );
        }

    }

}
