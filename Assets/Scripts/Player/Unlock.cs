using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public int index = -1;
    public GameObject door;

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
        if (distance <= 3)
        {
            actionText.GetComponent<Text>().text = "Открыть замок";
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
        }
        if (distance > 3)
        {
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (distance <= 3 && FindObjectOfType<Inventory>().CheckKey(index))
            {
                this.GetComponent<BoxCollider>().enabled = false;
                door.GetComponent<DoorOpen>().isClosed = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                actionCross.SetActive(false);
                FindObjectOfType<AudioManager>().Play("unlockSound");
                //FindObjectOfType<Inventory>().TakeKey(index);
                //gameObject.SetActive(false);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("lockedDoorSound");
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
