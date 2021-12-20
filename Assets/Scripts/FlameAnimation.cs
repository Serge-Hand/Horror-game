using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimation : MonoBehaviour
{
    public int lightMode;
    public GameObject flameLight;

    void Update()
    {
        if (lightMode == 0)
        {
            StartCoroutine(AnimateLight());
        }
    }

    IEnumerator AnimateLight()
    {
        lightMode = Random.Range(1, 4);
        switch (lightMode) {
            case 1:
                flameLight.GetComponent<Animation>().Play("TorchAnim1");
                break;
            case 2:
                flameLight.GetComponent<Animation>().Play("TorchAnim2");
                break;
            case 3:
                flameLight.GetComponent<Animation>().Play("TorchAnim3");
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(0.99f);
        lightMode = 0;
    }
}
