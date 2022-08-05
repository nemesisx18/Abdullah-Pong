using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;

    public bool isRight;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        rig.velocity = speed;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        rig.velocity = speed;
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Kanan")
        {
            isRight = true;
        }
        else if (other.tag == "Kiri")
        {
            isRight = false;
        }
    }

}
