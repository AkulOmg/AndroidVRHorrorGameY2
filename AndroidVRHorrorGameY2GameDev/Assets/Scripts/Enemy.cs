using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GlobalData gd;
    Rigidbody rb;
    public float speed = 3f;
    Vector3 direction = new Vector3(1f, 0f, 0f);
    bool up, down, right, left;
    int lastDir = 4;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        gd = GameObject.Find("GameManager").GetComponent<GlobalData>();
        ChangeDirection();

    }

    public void CollCheck(int d, bool c)
    {
        if (d == 0) up = c;
        if (d == 1) down = c;
        if (d == 2) right = c;
        if (d == 3) left = c;

        //print(" up " + up + " down " + down + " right " + right + "left" + left); 
        if (d == lastDir)
        {
            ChangeDirection();
        }

    }
    //while Loop
    public void ChangeDirection()
    {
        bool newDir = false;
        int loopCheck = 0;
        while (!newDir)
        {
            int r = Random.Range(0, 4);
            if (r == 0 && !up)
            {
                SetDirection(0);
                newDir = true;
            }
            if (r == 1 && !down)
            {
                SetDirection(1);
                newDir = true;
            }
            if (r == 2 && !right)
            {
                SetDirection(2);
                newDir = true;
            }
            if (r == 3 && !left)
            {
                SetDirection(3);
                newDir = true;
            }


            loopCheck++;
            if (loopCheck >= 10)
            {
                print("Infinite Loop Detected");
                break;
            }
        }
    }

    void SetDirection(int d)
    {
        if (d == 0)
        {
            direction = new Vector2(0f, 1f);

        }
        if (d == 1)
        {
            direction = new Vector2(0f, -1f);

        }
        if (d == 2)
        {
            direction = new Vector2(1f, 0f);

        }
        if (d == 3)
        {
            direction = new Vector2(-1f, 0f);

        }
        lastDir = d;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
    //
    // Prints Collisision when enemy hits somthing
    // private void OnCollisionEnter2D(Collision2D collision)
    // {

    //     print("Collision");
    // }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            collision.gameObject.transform.position = gd.lastCheckPoint;
            GameObject.Find("GameManager").GetComponent<GlobalData>().Health--;
            GameObject.Find("GameManager").GetComponent<GlobalData>().UpdateLives();

            Physics.IgnoreLayerCollision(9, 10, true);
        }
    }

}