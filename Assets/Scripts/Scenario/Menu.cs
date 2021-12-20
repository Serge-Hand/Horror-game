using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject screen;
    public void StartGame()
    {
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        screen.SetActive(true);
        screen.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(2.99f);
        SceneManager.LoadScene("SampleScene");
    }
}
