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
    GameObject BrainIcon;
    private GameObject FlashLight;
    //private GameObject UiManager;

    // Start is called before the first frame update
    void Start()
    {
        //UiManager = GameObject.Find("UiManager");
        BrainIcon = GameObject.Find("Brain_full");
        reloadCooldown = 0.0f;
        FlashLight = GameObject.Find("FlashLightParent");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGamePaused)
            return;

        if(reloadCooldown > 0.0f)
        {
            reloadCooldown -= Time.deltaTime;
            if (reloadCooldown < 0.0f)
                reloadCooldown = 0.0f;
            UiManager.instance.UpdateReloadBar();
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
    }

    public void RefillReload(float value)
    {
        reloadCooldown -= value;
        UiManager.instance.UpdateReloadBar();
    }

    void Shoot()
    {
        reloadCooldown = reloadTime;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        FlashLight.GetComponent<Animator>().enabled = true;
        FlashLight.GetComponent<AudioSource>().Play();
    }

    public void TakeDamage(float value)
    {
        health -= value;
        var Icon = BrainIcon.GetComponent<Image>();
        Icon.fillAmount = health/100;
        if (health <= 0.0f)
            GameManager.instance.OnDie();
        Debug.Log("AU");
        UiManager.instance.UpdateHealthBar();
    }
}
