using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotion : MonoBehaviour
{
    CharacterController cc;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20f;

    Vector3 moveDir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDir *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
            }

        }
        else
        {

        }
        moveDir.y -= gravity * Time.deltaTime;
        cc.Move(moveDir * Time.deltaTime);
        if(Input.GetAxis("Horizontal") != 0)
        {
            float xScale = Mathf.Abs(transform.localScale.x);
            if (Input .GetAxis("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-xScale, transform.lossyScale.y, transform.lossyScale.z);
            }
            else
            {
                transform.localScale = new Vector3(xScale, transform.lossyScale.y, transform.lossyScale.z);
            }
        }
    }
}
