using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public bool start;
    public bool start2;
    public float time;
    public float time2;

    public Vector3 paddleInfo;

    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        paddleInfo = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {
        //get input
        MoveObject(GetInput());

        if (start)
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                transform.localScale = paddleInfo;

                start = false;
                time = 0;
            }
        }

        if (start2)
        {
            time2 += Time.deltaTime;
            if (time2 > 5)
            {
                speed = speed / 2;

                start2 = false;
                time2 = 0;
            }
        }
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector3.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector3.down * speed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("kecepatan: " + movement);
        rig.velocity = movement;
    }

    public void PULongPaddle()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
        start = true;
    }

    public void PUSpeedPaddle()
    {
        speed = speed * 2;
        start2 = true;
    }

}
