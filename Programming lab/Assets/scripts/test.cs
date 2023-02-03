using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement3d : MonoBehaviour
{
    Transform trans;
    Rigidbody body;


    public float speed;
    public float jumpPower;
    public float rot;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        Walk();
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
            rot += speed / 50;
            trans.rotation = Quaternion.Euler(0, rot, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rot -= speed / 50;
            trans.rotation = Quaternion.Euler(0, rot, 0);
        }
    }
}