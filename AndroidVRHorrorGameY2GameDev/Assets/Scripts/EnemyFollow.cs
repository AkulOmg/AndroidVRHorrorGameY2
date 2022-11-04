using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyFollow : MonoBehaviour
{

    public Transform Player;

    [SerializeField]
    int MoveSpeed = 4;

    [SerializeField]
    int MaxDist = 10;
    [SerializeField]
    int MinDist = 5;

    public Animator anim;


    /*Enemy random direction on collison*/

    public Vector3 direction;

    void Start()
    {
        direction = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f)).normalized;
        transform.Rotate(direction);

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            anim.SetBool("IsRunning", false);
            Debug.Log("EnemyRunning");

            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                anim.SetBool("IsRunning", true);
                Debug.Log("Enemyidle");
            }
        
        }


        /*Animator Script*/

        


            /*Enemy random direction on collison*/


        void Update()
            {
            Vector3 newPos = transform.position + direction * MoveSpeed * Time.deltaTime;
            GetComponent<Rigidbody>().MovePosition(newPos);
            
        }

       


    }

    /*Enemy random direction on collison*/


    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision");
        if (col.gameObject.tag == "Enemy")
        {
            direction = col.contacts[0].normal;
            direction = Quaternion.AngleAxis(Random.Range(-70.0f, 70.0f), Vector3.forward) * direction;
            transform.rotation = Quaternion.LookRotation(direction);
            
        }
    }

}