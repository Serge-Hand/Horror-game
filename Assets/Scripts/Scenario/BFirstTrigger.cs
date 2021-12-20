using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BFirstTrigger : MonoBehaviour
{
    //public GameObject player;
    public GameObject subText;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ScenePlayer());
    }

    private IEnumerator ScenePlayer()
    {
        subText.GetComponent<Text>().text = "Меня пугает это мрачное место.";
        yield return new WaitForSeconds(2.5f);
        subText.GetComponent<Text>().text = "";
        gameObject.SetActive(false);
    }
}
