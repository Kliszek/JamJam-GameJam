using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float reloadCooldown;
    public float reloadTime = 10.0f;
    public GameObject bulletPrefab;
    public float health = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        reloadCooldown = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(reloadCooldown > 0.0f)
        {
            reloadCooldown -= Time.deltaTime;
            if (reloadCooldown < 0.0f)
                reloadCooldown = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && reloadCooldown <= 0.0f)
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Q) && GameManager.instance.CanUseUltimate)
        {
            Ultimate();
        }
    }

    public void Ultimate()
    {
        GameManager.instance.UseUltimate();
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<Ghost>().Die();
        }
    }

    public void RefillReload(float value)
    {
        reloadCooldown -= value;
    }

    void Shoot()
    {
        reloadCooldown = reloadTime;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    public void TakeDamage(float value)
    {
        health -= value;
        if (health <= 0.0f)
            GameManager.instance.OnDie();
        Debug.Log("AU");
    }
}
