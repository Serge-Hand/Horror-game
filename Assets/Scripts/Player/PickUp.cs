using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject pistol;
    public GameObject pistolHand;
    //public AudioSource pickSound;
    public GameObject actionCross;

    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        actionCross.SetActive(true);
        if (distance <= 2)
        {
            actionText.GetComponent<Text>().text = "Взять пистолет";
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
                pistol.SetActive(false);
                pistolHand.SetActive(true);
                actionCross.SetActive(false);
                FindObjectOfType<AudioManager>().Play("pickGunSound");
                FindObjectOfType<UIManager>().TurnOnAmmo();
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
