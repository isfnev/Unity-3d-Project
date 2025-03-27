using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xValue = 0, yValue = 1, zValue = 0;
    [SerializeField]float speed = 2;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(xValue*speed, yValue*speed, zValue*speed);
    }
}
