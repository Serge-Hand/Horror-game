using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidWall : Wander
{
    public float avoidDistance;
    public float lookAhead;

    public override void Awake()
    {
        base.Awake();
        target = new GameObject();
        target.AddComponent<Agent>();
    }

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        Vector3 position = transform.position;
        Vector3 rayVector = agent.velocity.normalized * lookAhead;
        Vector3 direction = rayVector;
        RaycastHit hit;

        if (Physics.Raycast(position, direction, out hit, lookAhead))
        {
            position = hit.point + hit.normal * avoidDistance;
            target.transform.position = position;
            steering = base.GetSteering();
        }
        return steering;
    }
}
