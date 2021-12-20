using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject door;
    //public AudioSource openSound;
    public GameObject actionCross;

    public bool isClosed = false;

    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        actionCross.SetActive(true);
        if (distance <= 2)
        {
            actionText.GetComponent<Text>().text = "Открыть дверь";
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
                if (!isClosed)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    actionDisplay.SetActive(false);
                    actionText.SetActive(false);
                    door.GetComponent<Animation>().Play("DoorAnim");
                    FindObjectOfType<AudioManager>().Play("creakSound");
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("lockedDoorSound");
                }
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
