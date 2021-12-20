using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ate : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            gameObject.SetActive(false);
        }
    }
}
