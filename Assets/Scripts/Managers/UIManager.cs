using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject actionButton;
    public GameObject actionText;
    public GameObject actionCross;
    public GameObject subText;
    public GameObject ammoImg;
    public GameObject ammoCount;
    public GameObject hpBar;
    public GameObject hit;
    public GameObject cross;
    public GameObject deathScreen;

    public float health = 100;
    public float startHealth = 100;
    private int allAmmo = 10;
    private int curAmmo = 8;

    public void AddAmmo(int count)
    {
        allAmmo += count;
        SetAmmo();
    }
    public void MinAmmo()
    {
        if (curAmmo > 0)
        {
            curAmmo--;
            SetAmmo();
        }
    }
    public void Reload()
    {
        int i;
        for (i = 0; i < 8 - curAmmo; i++)
        {
            if (allAmmo > 0)
                allAmmo--;
            else
                break;
        }
        if (i != 0)
        {
            curAmmo += i;
            SetAmmo();
            FindObjectOfType<AudioManager>().Play("reloadSound");
        }
    }
    private void SetAmmo()
    {
        ammoCount.GetComponent<Text>().text = curAmmo + "/" + allAmmo;
    }
    public int GetAmmo()
    {
        return curAmmo;
    }

    public void SetDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            hpBar.GetComponent<Image>().fillAmount = health / startHealth;
            StartCoroutine(Hit());
        }
        else
        {
            deathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("DeathCamera").SetActive(true);
            GameObject.Find("Character").SetActive(false);
        }
    }

    IEnumerator Hit()
    {
        hit.SetActive(true);
        yield return new WaitForSeconds(0.39f);
        hit.SetActive(false);
    }

    public GameObject GetActionButton()
    {
        return actionButton;
    }
    public GameObject GetActionText()
    {
        return actionText;
    }
    public GameObject GetActionCross()
    {
        return actionCross;
    }
    public GameObject GetSubText()
    {
        return subText;
    }

    public void TurnOnAmmo()
    {
        ammoImg.SetActive(true);
        ammoCount.SetActive(true);
        hpBar.SetActive(true);
    }
}
