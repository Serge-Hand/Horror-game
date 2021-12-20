using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GateTrigger : MonoBehaviour
{
    public float distance;
    private GameObject actionDisplay;
    private GameObject actionText;
    private GameObject actionCross;

    void Start()
    {
        GameObject ui = GameObject.Find("UIManager");
        actionDisplay = ui.GetComponent<UIManager>().GetActionButton();
        actionText = ui.GetComponent<UIManager>().GetActionText();
        actionCross = ui.GetComponent<UIManager>().GetActionCross();
    }

    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        actionCross.SetActive(true);
        if (distance <= 2)
        {
            actionText.GetComponent<Text>().text = "Открыть ворота";
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
        }
        if (distance > 2)
        {
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (distance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                FindObjectOfType<AudioManager>().Play("unlockGateSound");
                StartCoroutine(Open());
            }
        }
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("lvl2");
    }

    private void OnMouseExit()
    {
        actionCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
