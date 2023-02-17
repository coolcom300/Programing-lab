using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    Transform trans;
    Rigidbody body;


    public float speed;
    public float turnSpeed;
    public float jumpPower;
    public float rot;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ScoreCount",1f,1f);
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
    }
    void ScoreCount()
    {
        score.scoresScriptInstance.scoreNumber++;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Walk();
        Jump();
    }

    void Walk()
    {
        //forward+back
        if (Input.GetKey(KeyCode.W))
        {
            trans.position += trans.forward * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, rot, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            trans.position += -trans.forward * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, rot, 0);
        }

        //right+left

        //if (Input.GetKey(KeyCode.D))
        //{
        //    trans.position += trans.right * Time.deltaTime * speed;
        //    trans.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    trans.position += -trans.right * Time.deltaTime * speed;
        //    trans.rotation = Quaternion.Euler(0, 0, 0);
        //}

        //Turning right left

        if (Input.GetKey(KeyCode.D))
        {
            rot += turnSpeed;
            trans.rotation = Quaternion.Euler(0, rot, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rot -= turnSpeed;
            trans.rotation = Quaternion.Euler(0, rot, 0);
        }
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            body.AddForce(trans.up * jumpPower,ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}