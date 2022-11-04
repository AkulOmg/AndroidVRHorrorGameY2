using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform warpTo;
    static bool justWarped;

    // Start is called before the first frame update
    void Start()
    {
        justWarped = true;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (justWarped == false)
        {
            collision.gameObject.transform.position = warpTo.position;
            justWarped = true;

        }
        else
        {
            justWarped = false;
        }

    }
}