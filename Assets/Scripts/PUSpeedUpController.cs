using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public float magnitude;
    public float maxTime;
    private float onTime;

    public PowerUpManager manager;

    private void Update()
    {
        onTime += Time.deltaTime;

        if(onTime > maxTime)
        {
            manager.RemovePowerUp(gameObject);
            onTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
