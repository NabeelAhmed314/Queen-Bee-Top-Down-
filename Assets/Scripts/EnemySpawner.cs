using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] spawnLoc;
    public float respawnTime = 1;
    public int Random_spawn;
    public int Random_enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyWave());
    }
    private void spawnEnemy()
    {
        Random_spawn = (int)Random.Range(0, 8);
        Random_enemy = (int)Random.Range(0, 5);
        GameObject obj = Instantiate(enemyPrefab[Random_enemy]) as GameObject;
        obj.transform.position = spawnLoc[Random_spawn].position;
        ScoreManager.Enemies++;
    }
    IEnumerator enemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
