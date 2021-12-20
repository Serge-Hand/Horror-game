using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : AgentBehaviour
{
    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;

    public override Steering GetSteering()
    {
        //вычисление скорости в зависимости от расстояния до цели
        //и радиуса замедления
        Steering steering = new Steering();
        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;
        float targetSpeed;
        if (distance < targetRadius)
        {
            GetComponent<Arrive>().enabled = false;
            return steering;

        }
        if (distance > slowRadius)
        {
            targetSpeed = agent.maxSpeed;
            return steering;
        }
        else
            targetSpeed = agent.maxSpeed * distance / slowRadius;

        //определение управляющих значений 
        //и ограничение скорости максимальным значением
        Vector3 desiredVelocity = direction;
        desiredVelocity *= targetSpeed;
        steering.linear = desiredVelocity - agent.velocity;
        steering.linear /= timeToTarget;
        if (steering.linear.magnitude > agent.maxAccel)
        {
            steering.linear.Normalize();
            steering.linear *= agent.maxAccel;
        }
        return steering;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, slowRadius);
    }
}
