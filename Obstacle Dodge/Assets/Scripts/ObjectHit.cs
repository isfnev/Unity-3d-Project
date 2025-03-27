using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.magenta;
            gameObject.tag = "Hit";
        }
    }
}
