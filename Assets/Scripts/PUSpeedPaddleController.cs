using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedPaddleController : MonoBehaviour
{
    public Collider2D ball;
    public float maxTime;
    private float onTime;

    public PowerUpManager manager;
    public PaddleController[] paddle;

    private void Update()
    {
        onTime += Time.deltaTime;

        if (onTime > maxTime)
        {
            manager.RemovePowerUp(gameObject);
            onTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (ball.GetComponent<BallController>().isRight)
            {
                paddle[0].PUSpeedPaddle();
            }

            if (!ball.GetComponent<BallController>().isRight)
            {
                paddle[1].PUSpeedPaddle();
            }

            manager.RemovePowerUp(gameObject);
        }
    }
}
