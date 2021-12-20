using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FSlamDoorTrigger : MonoBehaviour
{
    public GameObject zombie;
    public GameObject door;
    public GameObject torch;

    private void Start()
    {
        GameObject ui = GameObject.Find("UIManager");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            zombie.SetActive(true);
            torch.SetActive(true);
            StartCoroutine(ScenePlayer());
        }
    }

    private IEnumerator ScenePlayer()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Animator>().SetTrigger("SlamDoor");
        FindObjectOfType<AudioManager>().Play("slamDoorSound");
        yield return new WaitForSeconds(0.3f);
        FindObjectOfType<UIManager>().GetSubText().GetComponent<Text>().text = "Ааа!";
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<UIManager>().GetSubText().GetComponent<Text>().text = "";
        gameObject.SetActive(false);
    }
}
