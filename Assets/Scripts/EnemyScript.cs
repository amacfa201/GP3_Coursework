using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : GeneralBehaviours {
    public float arrivalRadius;
    public float maxSpeed;

    public Vector3 velocity;

    public GameObject player;
    
    void FixedUpdate () {
        ArrivalBehaviour(transform.position, player.transform.position);
	}

    public void ArrivalBehaviour(Vector3 agent, Vector3 target)
    {


        if (Vector3.Distance(agent, target) > arrivalRadius)
        {
            velocity = Vector3.Normalize(target - agent) * maxSpeed;
        }
        else
        {
            velocity = Vector3.Normalize(target - agent) * (maxSpeed * ((Vector3.Distance(agent, target)) / arrivalRadius));
        }


        if (velocity.sqrMagnitude > 0.0f)
        {
            transform.forward = Vector3.Normalize(new Vector3(velocity.x, velocity.y, velocity.z));
        }
        transform.position += new Vector3(velocity.x, velocity.y, velocity.z) * Time.deltaTime;

    }
}
