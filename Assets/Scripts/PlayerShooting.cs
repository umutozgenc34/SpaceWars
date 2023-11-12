using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootingInterval;
    private float intervalReset;

    // Start is called before the first frame update
    void Start()
    {
        intervalReset = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if (shootingInterval <=0)
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, shootPoint.position, Quaternion.identity);
    }
}
