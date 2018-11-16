using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField]

    protected float speed;

    public Rigidbody rigid;

    public GameObject ground;




    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        TerrainWrapping();
        

    }

    void FixedUpdate()
    {
        ////Added to allow player to jump
        //if (transform.position.y <= 0)
        //{
        //    rigid.constraints = RigidbodyConstraints.FreezePositionY;
        //}
        //else
        //{
        //    rigid.constraints = RigidbodyConstraints.None;
        //}

        //Input and movement code
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigid.AddForce(movement * speed);

        //Jump code
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    rigid.AddForce(Vector3.up * 50f);
        //}
    }

    //Calculates axes needed for new player postions for terrain wrapping before they are applied
    Vector3 updateX(float x)
    {
        return new Vector3(x, transform.position.y, transform.position.z);
    }


    Vector3 updateZ(float z)
    {
        return new Vector3(transform.position.x, transform.position.y, z);
    }

    //Finds the size of the world to allow dynamic world sizing 
    float getXBounds()
    {
        return ground.GetComponent<Renderer>().bounds.size.x / 2.0f;
    }

    float getZBounds()
    {
        return ground.GetComponent<Renderer>().bounds.size.z / 2.0f;
    }
    //

    //Collision Detection
    void OnCollisionEnter(Collision col)
    {
        //Enemy - Deletes Player
        if (col.gameObject.name == "blackHole")
        {
            Destroy(gameObject);
        }

        //Obstacles - Deletes Obstacle
        if (col.gameObject.name.StartsWith("Mushroom"))
        {
            Destroy(col.gameObject);
        }
    }


    //Places player on side opposite if they fall off
    void TerrainWrapping()
    {
        if (transform.position.x > getXBounds() || transform.position.x < -getXBounds())
        {
            transform.position = updateX(-transform.position.x);
        }

        if (transform.position.z > getZBounds() || transform.position.z < -getZBounds())
        {
            transform.position = updateZ(-transform.position.z);
        }
    }



    #region Old Lab2 code
    //void OnCollisionExit(Collision col)
    //{
    //    if (col.gameObject.tag == "Ground")
    //    {
    //        print("CExit with: " + col.gameObject);
    //    }

    //    if (col.gameObject.name == "redSphere")
    //    {
    //        print("CExit with: " + col.gameObject);
    //    }
    //}

    //void OnCollisionStay(Collision col)
    //{
    //    if (col.gameObject.tag == "Ground")
    //    {
    //        print("CS with: " + col.gameObject);
    //    }

    //    if (col.gameObject.name == "redSphere")
    //    {
    //        print("CS with: " + col.gameObject);
    //    }
    //}
    #endregion



}
