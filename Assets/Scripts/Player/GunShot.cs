using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public GameObject bulletHolePrefab;
    public GameObject flash;
    //public AudioSource gunshot;
    public Camera cam;

    public float range = 100f;
    public float damage = 5f;

    private bool isClicked = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isClicked)
            {
                if (FindObjectOfType<UIManager>().GetAmmo() > 0)
                    StartCoroutine(Fire());
                else
                    StartCoroutine(Empty());
            }
        }
        if (Input.GetButtonDown("Reload"))
        {
            FindObjectOfType<UIManager>().Reload();
        }
    }

    IEnumerator Fire()
    {
        isClicked = true;
        GetComponent<Animator>().SetTrigger("Shot1");
        flash.SetActive(true);
        yield return new WaitForSeconds(0.35f);
        FindObjectOfType<AudioManager>().Play("shotSound");
        FindObjectOfType<UIManager>().MinAmmo();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            LockShot shot = hit.transform.GetComponent<LockShot>();
            if (shot != null)
            {
                shot.Damage();
            }
            ZombieBehaviour zombie = hit.transform.GetComponent<ZombieBehaviour>();
            if (zombie != null)
            {
                zombie.TakeDamage(damage);
            }
            if (hit.collider.tag.Equals("Zombie"))
            {

            }
            else
            {
                //Instantiate(bulletHolePrefab, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        yield return new WaitForSeconds(0.3f);
        flash.SetActive(false);
        isClicked = false;
    }

    IEnumerator Empty()
    {
        isClicked = true;
        FindObjectOfType<AudioManager>().Play("emptyAmmoSound");
        yield return new WaitForSeconds(0.5f);
        isClicked = false;
    }
}
