using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {
    public float age;
    public float minDeathAge;
    public float maxDeathAge;
    public float deathAge;
    public float halfLife;

    public bool healthy = true;
    public bool consumable = true;

    public Rigidbody rigid;



	// Use this for initialization
	void Start () {
        deathAge = Random.Range(minDeathAge, maxDeathAge);
        halfLife = deathAge / 2;
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        age += Time.deltaTime;
        if (age >= deathAge)
        {
            Dead();
        }
	}


    void Dead()
    {
        rigid.AddForce(Vector3.up * 25);
        Destroy(this.gameObject, 5f);
    }
}
