using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {
    public float age;
    public float minDeathAge;
    public float maxDeathAge;
    public float deathAge;
    public float halfLife;
    float r;

    bool healthy = true;
    public bool consumable = true;

    public Rigidbody rigid;

    Renderer rend;


	// Use this for initialization
	void Start () {
        deathAge = Random.Range(minDeathAge, maxDeathAge);
        halfLife = deathAge / 2;
        rigid = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        float r = Random.Range(0.5f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        age += Time.deltaTime;
        if (age >= deathAge)
        {
            Dead();
        }
        if (age >= halfLife)
        {
            healthy = false;
            rend.material.color = Color.Lerp(Color.white, Color.black, 1);
        }
        Rotate();
	}


    void Dead()
    {
        rigid.AddForce(Vector3.up * 25);
        Destroy(this.gameObject, 5f);
    }

    public bool isHealthy()
    {
        return healthy;
    }

    void Rotate()
    {
        
        float rotFactor = age += r;
        transform.Rotate(new Vector3(0f, Mathf.Sin(rotFactor), 0f) * Time.deltaTime);
    }
}
