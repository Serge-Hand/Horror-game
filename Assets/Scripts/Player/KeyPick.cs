using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPick : MonoBehaviour
{
    public int index = -1;

    public float distance;
    private GameObject actionDisplay;
    private GameObject actionText;
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
        if (distance <= 10)
        {
            actionText.GetComponent<Text>().text = "Поднять ключ";
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
        }
        if (distance > 10)
        {
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (distance <= 10)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                actionCross.SetActive(false);
                FindObjectOfType<AudioManager>().Play("keySound");
                FindObjectOfType<Inventory>().TakeKey(index);
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
