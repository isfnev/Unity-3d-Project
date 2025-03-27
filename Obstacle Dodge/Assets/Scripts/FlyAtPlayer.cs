using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Transform myPlayer;
    Vector3 playerPosition;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        playerPosition = myPlayer.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        DestroyWhenReached();
    }

    void DestroyWhenReached()
    {
        if (playerPosition == transform.position)
            Destroy(gameObject);
    }

    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed*Time.deltaTime);
    }
}
