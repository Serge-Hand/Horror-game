using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTableTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public GameObject subText;
    public GameObject pistolTrig;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        player.SetActive(false);
        FindObjectOfType<UIManager>().cross.SetActive(false);
        cam.SetActive(true);
        StartCoroutine(ScenePlayer());
    }

  /*  private void Update()
    {
        if (isTriggerd)
        {
            var q = Quaternion.LookRotation(pistol.transform.position - transform.position);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, q, 100f * Time.deltaTime);
        }
    }*/

    private IEnumerator ScenePlayer()
    {
        subText.GetComponent<Text>().text = "Стол? На нём настоящий револьвер?";
        yield return new WaitForSeconds(2.8f);
        cam.SetActive(false);
        subText.GetComponent<Text>().text = "";
        player.SetActive(true);
        FindObjectOfType<UIManager>().cross.SetActive(true);
        gameObject.SetActive(false);
        pistolTrig.SetActive(true);
    }

   /* private void Rotate()
    {
        isTriggerd = true;
    }

    private void TransformAngle()
    {
        Vector3 newPosPlayer;//, newPosCam;

        newPosPlayer = player.transform.rotation.eulerAngles;
        newPosPlayer.y += cam.transform.localEulerAngles.y;
        //newPosCam = tmp.transform.localEulerAngles;//!!!
       // newPosCam.x += cam.transform.localEulerAngles.x;

        cam.transform.localEulerAngles = new Vector3(0, 0, 0);
        //tmp.transform.localEulerAngles = newPosCam;
        player.transform.localEulerAngles = newPosPlayer; 
        //print(tmp.transform.eulerAngles);
    }*/
}
