using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public AudioClip collectSound;
    public GameObject collectVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.Collect();

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position, 1f);
            }

            if (collectVFX != null)
            {
                Instantiate(collectVFX, transform.position, Quaternion.identity);
            }

            Destroy(gameObject, collectSound.length);
        }
    }
}
