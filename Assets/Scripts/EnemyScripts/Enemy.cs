using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Serializefield] protected float health;
    void Start()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        HurtSequence();
        if (health <= 0)
        {
            DeathSequence();
        }
    }

    public virtual void HurtSequence()
    {

    }

    public virtual void DeathSequence()
    {

    }

   
}
