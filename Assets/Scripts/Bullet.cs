using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float lifeTime = 0.0f;
    public float maxLifeTime = 5.0f;
    public float speed = 5.0f;
    public float wideningSpeed = 2.5f;

    private void Awake()
    {
        lifeTime = 0.0f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.localScale += Vector3.right * Time.deltaTime * wideningSpeed;

        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            other.GetComponent<Ghost>().Die();
    }
}
