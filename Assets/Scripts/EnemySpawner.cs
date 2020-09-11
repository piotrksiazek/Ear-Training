using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    [SerializeField] private float secondsToSpawn = default;
    private float timer;

    private void Start()
    {

    }
    void Update()
    {
        WaintUntilSpawn();
    }

    private void WaintUntilSpawn()
    {
        if (timer <= secondsToSpawn)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Instantiate(Enemy);
        }
    }

}
