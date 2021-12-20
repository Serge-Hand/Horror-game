using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Material disMat;
    Shader shader;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public IEnumerator DoDeath()
    {
        yield return new WaitForSeconds(2f);
        shader = disMat.shader;
        rend.material.shader = shader;
        for (float amount = -1; amount <= 1; amount += 0.01f)
        {
            rend.material.SetFloat("_amount", amount);
            yield return new WaitForSeconds(0.005f);
        }
    }
}
