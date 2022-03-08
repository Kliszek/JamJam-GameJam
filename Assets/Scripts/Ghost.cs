using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//using Unity.AI.Navigation;

public class Ghost : MonoBehaviour
{

    public float damage;
    private Transform playerInstance;
    private NavMeshAgent agent;
    private GameObject LampIcon;

    // Start is called before the first frame update
    void Start()
    {
        playerInstance = GameManager.playerInstance.transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
        LampIcon = GameObject.Find("LightBulb");
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = playerInstance.position;
    }

    public void Die()
    {
        GameManager.playerInstance.RefillReload(5.0f);
        GameManager.instance.ultimateProgress += 10.0f;
        LampIcon.GetComponent<Image>().fillAmount = GameManager.instance.ultimateProgress/100;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player got hit!");
            //GameManager.playerInstance.TakeDamage(damage);

            GameManager.playerInstance.TakeDamage(damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player got hit!");
            GameManager.playerInstance.TakeDamage(damage);
        }
    }
}
