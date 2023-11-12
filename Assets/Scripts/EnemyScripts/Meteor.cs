using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

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
        
    }

    public override void HurtSequence()
    {
        
    }

    public override void DeathSequence()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            Destroy(otherCollider.gameObject);
        }
        
    }
}
