using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBulelt : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float damage;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject miniBullets;
    [SerializeField] private Transform[] spawnPoint;

    void Start()
    {
        rb.velocity = Vector2.down * speed;
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed*Time.deltaTime);
    }

    IEnumerator Explode()
    {
        float randomExplodeTime = Random.Range(1.5f, 2.5f);
        yield return new WaitForSeconds(randomExplodeTime);
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(miniBullets, spawnPoint[i].position, spawnPoint[i].rotation);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
