using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Collisionhandling : MonoBehaviour
{
    [SerializeField] float finishDelay=0;
    [SerializeField] AudioClip deathExplosion;
    [SerializeField] AudioClip Success;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem successParticle;
    AudioSource audioSource;
    bool isControllable = true;
    bool isCollidable = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ResponseToDebugKeys();
    }

    void ResponseToDebugKeys()
    {
        if(Keyboard.current.lKey.wasPressedThisFrame)
        {
            NextScene();
        }
        else if(Keyboard.current.cKey.wasPressedThisFrame)
            isCollidable = !isCollidable;
    }
    private void OnCollisionEnter(Collision other)
    {   
        if (!isControllable || !isCollidable) return;

        switch (other.gameObject.tag)
        {
            case "Friendly":
                fuelObject();
                break;
            case "Respawn":break;
            case "Finish":
                SceneFinishDelay();
                break;
            default:
                SceneRespawnSequence();
                break;
        }
    }

    private void SceneRespawnSequence()
    {
        audioSource.Stop();
        explosionParticle.Play();
        gameObject.GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(deathExplosion);
        Invoke("Respawn", 2f);
        isControllable = false;        
    }

    private void SceneFinishDelay()
    {
        audioSource.Stop();
        successParticle.Play();
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("NextScene", finishDelay);
        audioSource.PlayOneShot(Success);
        isControllable = false;
    }

    private void NextScene()
    {
        int currentScence = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScence + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
            nextScene = 0;

        SceneManager.LoadScene(nextScene);
    }

    private void fuelObject()
    {
        Debug.Log("+100 fuel");
    }

    private void Respawn()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
