using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hitsToDestroy = 3;
    public bool protection = false;

    [SerializeField] private GameObject[] shieldBase;


    private void OnEnable()
    {
        hitsToDestroy = 3;
        for (int i = 0; i < shieldBase.Length; i++)
        {
            shieldBase[i].SetActive(true);
        }
        protection = true;
    }

    private void UpdateUI()
    {
        switch (hitsToDestroy)
        {
            case 0:
                for (int i = 0; i < shieldBase.Length; i++)
                {
                    shieldBase[i].SetActive(false);
                }
                break;

            case 1:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(false);
                shieldBase[2].SetActive(false);
                break;

            case 2:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(true);
                shieldBase[2].SetActive(false);
                break;

            case 3:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(true);
                shieldBase[2].SetActive(true);
                break;

            default:
                Debug.Log("Something is wrong");
                break;
        }
    }

    private void DamageShield()
    {
        hitsToDestroy -= 1;
        if (hitsToDestroy <=0)
        {
            hitsToDestroy = 0;
            protection = false;
            gameObject.SetActive(false);
        }

        UpdateUI();
    }

    public void RepairShield()
    {
        hitsToDestroy = 3;
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy ))
        {
            if (collision.CompareTag("Boss"))
            {
                hitsToDestroy = 0;
                DamageShield();
                return;
            }
            enemy.TakeDamage(100);
            DamageShield();
        }
        else
        {
            Destroy(collision.gameObject);
            DamageShield();
        }
    }
}
