using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //* Parameters - for tuning, typically set in the editor.
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 80f;
    [SerializeField] AudioClip mainEngine;

    //* Cache - references for readability of speed.
    Rigidbody rb;
    AudioSource audioSource;

    //* State - private instance (member) variables.
    // bool isAlive;

    //* Methods - private first followed by public.
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
    {
        ApplyRotation(rotationThrust);
    }
    else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        // The RigidBody is responsible for updating what happens with the physics or responding
        // to collisions.
        // Before you take manual control of rotation, you want to freeze the physics system's
        // rotation.
        // This prevents a constraint bug where the two systems, manual and physics control systems,
        // fight with each other. 
        rb.freezeRotation = true; // Freezing rotation so we can manually rotate.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreezing rotation so the physics system can take over.
    }
}
