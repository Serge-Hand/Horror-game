using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public GameObject trigger;
    private bool[] lockOpen = { false, false, false };

    public void Unlock(int index)
    {
        lockOpen[index] = true;
        if (lockOpen[0] && lockOpen[1] && lockOpen[2])
        {
            StartCoroutine(Opened());
        }
    }

    IEnumerator Opened()
    {
        yield return new WaitForSeconds(0.3f);
        FindObjectOfType<AudioManager>().Play("gateOpenSound");
        trigger.SetActive(true);
    }
}
