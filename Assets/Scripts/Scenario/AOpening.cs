using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AOpening : MonoBehaviour
{
    public GameObject player;
    public GameObject entryCam;
    public GameObject cam;
    public GameObject fadeInScreen;
    public GameObject fadeScreen;
    public GameObject subText;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player.SetActive(false);
        FindObjectOfType<UIManager>().cross.SetActive(false);
        StartCoroutine(ScenePlayer());
    }

    private IEnumerator ScenePlayer()
    {
        fadeScreen.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1.5f);
        fadeScreen.SetActive(false);
        subText.GetComponent<Text>().text = "Мы можем строить планы на будущее, копить деньги на всякие мелочи.";
        yield return new WaitForSeconds(4.5f);
        subText.GetComponent<Text>().text = "Но никто не может себе представить, что сегодняшний день может стать последним...?";
        yield return new WaitForSeconds(4.5f);
        subText.GetComponent<Text>().text = "";
        fadeInScreen.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(0.9f);
        fadeScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        entryCam.GetComponent<Animator>().SetTrigger("Next");
        yield return new WaitForSeconds(0.1f);
        fadeInScreen.SetActive(false);

        fadeScreen.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1.5f);
        fadeScreen.SetActive(false);
        subText.GetComponent<Text>().text = "Он не ожидал, что субботний поход в бар с друзьями обернется трагедией.";
        yield return new WaitForSeconds(4.5f);
        subText.GetComponent<Text>().text = "Теперь он даже не уверен, что увидит рассвет следующего дня.";
        yield return new WaitForSeconds(4.5f);
        subText.GetComponent<Text>().text = "";
        fadeInScreen.SetActive(true);
        fadeInScreen.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(3f);
        fadeInScreen.SetActive(false);

        FindObjectOfType<UIManager>().cross.SetActive(true);
        entryCam.SetActive(false);
        player.SetActive(true);
        fadeScreen.SetActive(true);
        fadeScreen.GetComponent<Animation>().Play();
        player.GetComponent<PlayerMovement>().isLocked = true;
        cam.GetComponent<Animator>().SetBool("isOpening", true);
    
        subText.GetComponent<Text>().text = "Где я..?";
        yield return new WaitForSeconds(2.5f);

        cam.GetComponent<Animator>().SetBool("isOpening", false);
        subText.GetComponent<Text>().text = "";
        player.GetComponent<PlayerMovement>().isLocked = false;
    }
}
