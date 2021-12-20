using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EGateTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public GameObject[] locks;
    public GameObject zombie;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        FindObjectOfType<UIManager>().cross.SetActive(false);
        player.SetActive(false);
        foreach (GameObject l in locks)
        {
            l.GetComponent<BoxCollider>().enabled = false;
        }
        cam.SetActive(true);
        StartCoroutine(ScenePlayer());
    }


    private IEnumerator ScenePlayer()
    {
        FindObjectOfType<UIManager>().GetSubText().GetComponent<Text>().text = "Эти замки похожи на тот, который я уже открыл. Но у меня только 1 ключ...";
        yield return new WaitForSeconds(5.8f);
        cam.SetActive(false);
        FindObjectOfType<UIManager>().GetSubText().GetComponent<Text>().text = "";
        player.SetActive(true);
        foreach (GameObject l in locks)
        {
            l.GetComponent<BoxCollider>().enabled = true;
        }
        FindObjectOfType<UIManager>().cross.SetActive(true);
        gameObject.SetActive(false);
        zombie.SetActive(true);
    }
}
