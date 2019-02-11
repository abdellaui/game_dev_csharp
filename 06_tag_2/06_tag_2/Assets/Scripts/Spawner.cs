using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject flyingEnemy = default;
    public Vector3 spawnPoint = default;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;

        InvokeRepeating("Spawn", 2f, 5f);
    }

    void Spawn()
    {
        Instantiate(flyingEnemy, spawnPoint, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
