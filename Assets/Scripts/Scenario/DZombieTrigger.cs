using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DZombieTrigger : MonoBehaviour
{
    public GameObject zombie;
    private GameObject subText;

    private void Start()
    {
        GameObject ui = GameObject.Find("UIManager");
        subText = ui.GetComponent<UIManager>().GetSubText();
    }
    private void OnTriggerEnter(Collider other)
    {
        zombie.SetActive(true);
        StartCoroutine(ScenePlayer());
    }

    private IEnumerator ScenePlayer()
    {
        //subText.GetComponent<Text>().text = "Что..?!";
        yield return new WaitForSeconds(0.5f);
        //subText.GetComponent<Text>().text = "";
        gameObject.SetActive(false);
    }
}
