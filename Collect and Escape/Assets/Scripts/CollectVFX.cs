using UnityEngine;

public class CollectVFX : MonoBehaviour
{
    private float lifetime = 0.5f;
    private Vector3 targetScale = new Vector3(1, 1, 1);

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * 10);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
