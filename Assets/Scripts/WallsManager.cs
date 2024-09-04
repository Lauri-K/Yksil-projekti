using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsManager : MonoBehaviour
{
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private Rigidbody2D lRb;
    [SerializeField] private Rigidbody2D rRb;

    public bool hitLeft = false;
    public bool hitRight = false;
    private bool gameOverOnce = false;

    [SerializeField] private Vector2 targetPosition;

    private float wallSpeed = 0.25f;
    void Start()
    {
        lRb = leftWall.GetComponent<Rigidbody2D>();
        rRb = rightWall.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GameOver();
    }

    void FixedUpdate()
    {
        lRb.velocity = new Vector2(1 * wallSpeed, lRb.velocity.y);
        rRb.velocity = new Vector2(-1 * wallSpeed, rRb.velocity.y);
    }

    void GameOver()
    {
        if (hitLeft && hitRight && !gameOverOnce)
        {
            Debug.Log("Player gets crushed");
            gameOverOnce = true;
        }
    }
}
