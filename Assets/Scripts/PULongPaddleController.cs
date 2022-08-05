using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongPaddleController : MonoBehaviour
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
            if(ball.GetComponent<BallController>().isRight)
            {
                paddle[0].PULongPaddle();
            }

            if (!ball.GetComponent<BallController>().isRight)
            {
                paddle[1].PULongPaddle();
            }

            manager.RemovePowerUp(gameObject);
        }
    }
}
