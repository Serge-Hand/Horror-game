using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Away : MonoBehaviour
{
    public GameObject target;

    private float speed;
    private bool move = true;
    private Vector3 targetPos;
    private float distance = 5;

    private void Awake()
    {
        float time = target.GetComponent<Projectile>().GetLandingТime();
        speed = (distance / time) * 2;
        targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);

        EditorApplication.isPaused = true;
    }

    private void Update()
    {
        if (move) {
            float step = speed * Time.deltaTime;
            //Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                move = false;
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}
