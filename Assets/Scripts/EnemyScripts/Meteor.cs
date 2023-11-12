using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    [SerializeField] private float rotateSpeed;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public override void HurtSequence()
    {
        
    }

    public override void DeathSequence()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            PlayerStats player = otherCollider.GetComponent<PlayerStats>();
            player.PlayerTakeDamage(damage);
            Destroy(gameObject);
            //Destroy(otherCollider.gameObject);
        }
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
