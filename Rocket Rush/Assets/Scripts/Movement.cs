using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] float thrustStrength=1000;
    [SerializeField] InputAction rotation;
    [SerializeField] float rotationStrength=4f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;
    
    Rigidbody rb;
    AudioSource audioSource ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        mainBooster.Play();
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(mainEngine);
    }

    private void StopThrusting()
    {
        mainBooster.Stop();
        audioSource.Stop();
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            RotateRight();
        }
        else if (rotationInput > 0)
        {
            RotateLeft();
        }
        else
        {
            leftBooster.Stop();
            rightBooster.Stop();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(-rotationStrength);
        rightBooster.Play();
    }

    private void RotateRight()
    {
        ApplyRotation(rotationStrength);
        leftBooster.Play();
    }

    private void ApplyRotation(float rotationFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
