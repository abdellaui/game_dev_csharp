using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] GameObject enemy = default;
    Vector3 spawnPos1;
    Vector3 spawnPos2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnTag"))
        {
            Spawn();
            if(other != null)
                Destroy(other.gameObject);
        }
    }

    private void Spawn()
    {
        spawnPos1 = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0.5f, 10f));
        spawnPos1.y = enemy.transform.position.y;

        spawnPos2 = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, 0.5f, 10f));
        spawnPos2.y = enemy.transform.position.y;

        Instantiate(enemy, spawnPos1, Quaternion.identity);
        Instantiate(enemy, spawnPos2, Quaternion.identity);
    }
}
