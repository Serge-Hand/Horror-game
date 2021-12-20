using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject keyPrefab;
    public GameObject viewCollider;

    public float speed = 0.01f;
    public float health = 15f;

    private bool attackTrigger = false;
    private bool isAttacking = false;
    public bool isDead = false;
    private bool haveNoticed = false;

    private void Update()
    {
        if (!isDead)
        {
            //transform.LookAt(player.transform);
            var lookPos = player.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2f);
            if (!attackTrigger)
            {
                speed = 0.01f;
                gameObject.GetComponent<Animator>().SetTrigger("Walk");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
            }
            if (attackTrigger && !isAttacking)
            {
                speed = 0;
                gameObject.GetComponent<Animator>().SetTrigger("Attack");
                StartCoroutine(Attack());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!haveNoticed && other.tag.Equals("Player"))
        {
            Notice();
            return;
        }
        if (haveNoticed && other.tag.Equals("Player"))
        {
            attackTrigger = true;
        }
    }
    private IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<AudioManager>().Stop("themeMusic");
        FindObjectOfType<AudioManager>().SetVolume("combatMusic", 0.6f);
        FindObjectOfType<AudioManager>().Play("combatMusic");
    }

    private void Notice()
    {
        haveNoticed = true;
        gameObject.GetComponent<Wander>().enabled = false;
        gameObject.GetComponent<Agent>().enabled = false;
        viewCollider.SetActive(false);
        FindObjectOfType<AudioManager>().Play("zombieSound1");
        StartCoroutine(ScenePlayer());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            attackTrigger = false;
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        FindObjectOfType<AudioManager>().Play("punchSound");
        FindObjectOfType<UIManager>().SetDamage(21);
        yield return new WaitForSeconds(1f);
        //-health
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (!haveNoticed)
            Notice();
        if (health <= 0)
        {
            isDead = true;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
            StartCoroutine(FindObjectOfType<AudioManager>().StartFade("combatMusic", "themeMusic", 2, 0));
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Death[] body = FindObjectsOfType<Death>();
            foreach (Death ob in body)
            {
                if (ob.transform.IsChildOf(transform))
                    StartCoroutine(ob.DoDeath());
            }
            StartCoroutine(SpawnKey());
        }
    }

    IEnumerator SpawnKey()
    {
        yield return new WaitForSeconds(2f);
        if (keyPrefab != null)
            Instantiate(keyPrefab, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }

}
