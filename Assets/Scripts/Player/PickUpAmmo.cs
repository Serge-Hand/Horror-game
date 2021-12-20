using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpAmmo : MonoBehaviour
{
    public float distance;
    private GameObject actionDisplay;
    private GameObject actionText;
    //public AudioSource pickSound;
    private GameObject actionCross;

    private void Start()
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
            actionText.GetComponent<Text>().text = "Взять патроны";
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
                actionCross.SetActive(false);
                FindObjectOfType<AudioManager>().Play("pickGunSound");
                FindObjectOfType<UIManager>().AddAmmo(3);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseExit()
    {
        actionCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
