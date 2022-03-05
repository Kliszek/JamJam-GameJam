using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using Unity.AI.Navigation;

public class Ghost : MonoBehaviour
{

    public float damage;
    private Transform playerInstance;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        playerInstance = GameManager.playerInstance.transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = playerInstance.position;
    }

    public void Die()
    {
        GameManager.playerInstance.RefillReload(5.0f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player got hit!");
            //GameManager.playerInstance.TakeDamage(damage);
        }
    }
}
