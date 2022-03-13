using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//using Unity.AI.Navigation;

public class Ghost : MonoBehaviour
{

    public float damage = 10.0f;
    public float reloadRefillAmount = 2.0f;
    public float ultimateFillAmount = 7.0f;
    [HideInInspector]
    public bool died = false;
    private Transform playerInstance;
    private NavMeshAgent agent;
    private GameObject LampIcon;
    private Animator animator;

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
        if(!died)
            agent.destination = playerInstance.position;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        died = false;
    }

    public void Explode()
    {
        died = true;
        agent.destination = transform.position;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().AddExplosionForce(1500.0f, GameManager.playerInstance.transform.position, 100.0f);
        animator.Play("GhostDeath");
    }
    public void Die()
    {
        died = true;
        agent.destination = transform.position;
        //animator.SetBool("Dead", true);
        animator.Play("GhostDeath");
        GameManager.playerInstance.RefillReload(reloadRefillAmount);

        GameManager.instance.ChargeUltimate(ultimateFillAmount);

        LampIcon.GetComponent<Image>().fillAmount = GameManager.instance.NormalizedUltimate;
        //Destroy(gameObject);  //Ghost gameobject removal is handled in animator script!!!
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!died && other.tag == "Player")
        {
            Debug.Log("Player got hit!");
            //GameManager.playerInstance.TakeDamage(damage);

            GameManager.playerInstance.TakeDamage(damage);
            Die();
        }
    }

}
