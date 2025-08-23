using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openSpeed = 1f;
    public float openHeight = 3f;
    public AudioClip doorOpenSound;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private AudioSource audioSource;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.up * openHeight;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, openSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, openPosition) < 0.01f)
            {
                isOpening = false;
            }
        }
    }

    public void UnlockDoor()
    {
        if (!isOpening)
        {
            isOpening = true;

            if (doorOpenSound != null)
            {
                audioSource.PlayOneShot(doorOpenSound);
            }
        }
    }
}
