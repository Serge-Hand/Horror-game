using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstZombie : MonoBehaviour
{
    private bool isFall = true;
    private bool isCaption = false;

    private void Update()
    {
        if (GetComponent<ZombieBehaviour>().isDead && !isCaption)
        {
            isCaption = true;
            StartCoroutine(Caption());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFall)
        {
            FindObjectOfType<AudioManager>().Play("zombieFall");
            isFall = false;
        }
    }

    IEnumerator Caption()
    {
        FindObjectOfType<UIManager>().GetSubText().GetComponent<Text>().text = "Боже... Что это было?!";
        yield return new WaitForSeconds(4f);
        FindObjectOfType<UIManager>().GetSubText().GetComponent<Text>().text = "";
    }
}
