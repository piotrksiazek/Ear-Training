using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    private void Start()
    {

    }
    void Update()
    {
        Instantiate(Enemy);
    }
}
