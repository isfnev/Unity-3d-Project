using UnityEngine;

public class ScoreHit : MonoBehaviour
{
    int totalCollision = 0;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Hit")
        {
            totalCollision++;
            Debug.Log(totalCollision);
        }
    }
}
