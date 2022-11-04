using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public Animator anim;

    /*Walkling sound*/

    public AudioSource StragetWalkInForestGravelGrass;

    // Use this for initialization
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;


        /*Animator Script*/
        anim = GetComponent<Animator>();
        
    }

    //Update is called once per frame
    void Update()
    {

        /*Animator & Sound Script*/

        if (Input.GetKey("joystick button 7"))
        {
            anim.SetBool("IsWalking", true);

            /*StragetWalkInForestGravelGrass.Play(); */

        }
        else
        {
            anim.SetBool("IsWalking", false);
            /*StragetWalkInForestGravelGrass.Stop();*/
        }

        




        /*Mouse movement*/


        float mouseInput = Input.GetAxis("Horizontal");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);



        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("joystick button 1"))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
            Debug.Log("X is pressed");
        }
        else if (Input.GetKey("joystick button 7") && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
            Debug.Log("R2 is pressed");
            
        }
        else if (Input.GetKey("joystick button 6"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
            Debug.Log("L2 is pressed");
        }


    }

    

}