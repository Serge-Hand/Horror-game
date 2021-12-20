using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockShot : MonoBehaviour
{
    public GameObject door;
    public Material disMat;

    Shader shader;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    public void Damage()
    {
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        FindObjectOfType<AudioManager>().Play("lockSound");
        door.GetComponent<DoorOpen>().isClosed = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Collider>().enabled = false;
        shader = disMat.shader;
        rend.material.shader = shader;
        for (float amount = -1; amount <= 1; amount += 0.01f)
        {
            rend.material.SetFloat("_amount", amount);
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
