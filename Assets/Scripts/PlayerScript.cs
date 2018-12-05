using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : GeneralBehaviours
{
    public float sens;

    void FixedUpdate()
    {


        //Input and movement code
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigid.AddRelativeForce(movement * speed);
        transform.Rotate(new Vector3(transform.rotation.x, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * sens);
        //Jump code
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    rigid.AddForce(Vector3.up * 50f);
        //}
    }


}



    




