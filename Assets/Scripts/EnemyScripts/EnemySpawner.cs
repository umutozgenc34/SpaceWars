using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Camera cam;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    [Header("EnemyPrefabs")]
    [SerializeField] private GameObject[] enemy;

    private float enemyTimer;
    [Space(15)]
    [SerializeField] private float enemySpawnTime;
    [Header("BOSS")]
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private WinCondition winCon;

    

    
    void Start()
    {
        cam = Camera.main;
        StartCoroutine(SetBoundaries());
    }


    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        enemyTimer += Time.deltaTime;
        if (enemyTimer>=enemySpawnTime)
        {
            int RandomPick = Random.Range(0, enemy.Length);
            Instantiate(enemy[RandomPick], new Vector3(Random.Range(maxLeft, maxRight), yPos, 0), Quaternion.identity);
            enemyTimer = 0;
        }

    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);

        maxLeft = cam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = cam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;

        yPos = cam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }

    private void OnDisable()
    {
        if (winCon.canSpawnBoss == false)
            return;

        if (bossPrefab != null)
        {
            Vector2 spawnPos = cam.ViewportToWorldPoint(new Vector2(0.5f, 1.2f));
            Instantiate(bossPrefab, spawnPos, Quaternion.identity);
        }
    }
}
