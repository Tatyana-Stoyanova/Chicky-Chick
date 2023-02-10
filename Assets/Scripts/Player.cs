using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float speed = 10f;
    public float jumpSpeed = 50f;
    Animator an;
    bool isOnFloor = true;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void FixedUpdate()
    {
        //_rigidbody.AddRelativeForce(0f, 0f, speed);

        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
        {
            an.SetTrigger("IsJumping");
            //_rigidbody.AddForce(Vector3.up * jumpSpeed); 
            _rigidbody.MovePosition(_rigidbody.position + Vector3.up * jumpSpeed * Time.deltaTime);

        }

         if (Input.GetAxis("Horizontal") != 0 && isOnFloor)
         {
            an.SetBool("IsWalking", true);
            
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localEulerAngles = new Vector3(0, -90, 0);
                // _rigidbody.AddRelativeForce(0f, 0f, - Input.GetAxis("Horizontal") * speed);
                 _rigidbody.MovePosition(_rigidbody.position + new Vector3(Input.GetAxis("Horizontal"), 0f, 0f )*speed*Time.deltaTime);
                //_rigidbody.velocity = _rigidbody.position + new Vector3(Input.GetAxis("Horizontal"), 0f, 0f).normalized * speed;


            }
            else
            {
                transform.localEulerAngles = new Vector3(0, 90, 0);
                //  _rigidbody.AddRelativeForce(0f, 0f, Input.GetAxis("Horizontal") * speed);
                 _rigidbody.MovePosition(_rigidbody.position + new Vector3(Input.GetAxis("Horizontal"), 0f, 0f)*speed*Time.deltaTime);
                //_rigidbody.velocity = _rigidbody.position + new Vector3(Input.GetAxis("Horizontal"), 0f, 0f).normalized * speed;
            }
        }
         else
         {
            an.SetBool("IsWalking", false);
         }

    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Floor")
        {
            isOnFloor = true;
          //  an.SetBool("IsWalking", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isOnFloor = false;
            an.SetBool("IsWalking", false);
        }
    }
}
