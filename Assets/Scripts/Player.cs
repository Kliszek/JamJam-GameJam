using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    
    public float reloadCooldown;
    public float reloadTime = 10.0f;
    public float NormalizedReload => (reloadTime - reloadCooldown) / reloadTime;

    public GameObject bulletPrefab;
    public float health = 100.0f;
    public float maxHealth = 100.0f;
    public float NormalizedHealth => health / maxHealth;
    [SerializeField] private GameObject BrainIcon;

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
        if (GameManager.instance.ultimateUsed == false)
        {
            reloadCooldown = reloadTime;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    public void TakeDamage(float value)
    {
        health -= value;
        var Icon = BrainIcon.GetComponent<Image>();
        Icon.fillAmount = health/100;
        if (health <= 0.0f)
            GameManager.instance.OnDie();
        Debug.Log("AU");
    }
}
