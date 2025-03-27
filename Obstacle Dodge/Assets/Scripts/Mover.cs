using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] int moveSpeed = 1;
    void Start()
    {
        PrintInstruction();
    }

    void Update()
    {
        MovePlayer();
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome in the game!");
        Debug.Log("Move using arrow keys or wasd");
        Debug.Log("don't bump into objects!");
    }

    void MovePlayer()
    {
        float zValue = Input.GetAxis("Vertical")*Time.deltaTime*moveSpeed;
        float xValue = Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed;
        float yValue = 0;
        transform.Translate(xValue, yValue, zValue);
    }
}
