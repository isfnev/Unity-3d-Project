using UnityEngine;

public class Dropper : MonoBehaviour
{
    bool dropIt = false;
    MeshRenderer myMeshRenderer;
    Rigidbody myRigidbody;
    [SerializeField] short WaitUntil = 3;

    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
        myMeshRenderer.enabled = false;
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;
    }

    void Update()
    {
        if (!dropIt && Time.time > WaitUntil)
        {
            myMeshRenderer.enabled = true;
            myRigidbody.useGravity = true;
        }
    }
}
