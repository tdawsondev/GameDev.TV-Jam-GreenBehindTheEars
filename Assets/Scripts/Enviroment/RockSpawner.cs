using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public Vector2 spawnRange;

    public GameObject rockFab;

    float timer;

    private void Start()
    {
        timer = Random.Range(spawnRange.x, spawnRange.y);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        timer = Random.Range(spawnRange.x, spawnRange.y);
        GameObject go = Instantiate(rockFab, transform);
        
    }
}
