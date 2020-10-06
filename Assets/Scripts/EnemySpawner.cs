using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject enemyReference;
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
            CommonData.Instance.ReferenceEnemiesDict.Add(CommonData.Instance.CurrentEnemyIndex++, Instantiate(Enemy));

            CommonData.Instance.DictString.Add($"key: {CommonData.Instance.CurrentEnemyIndex - 1}"); //Delete
        }
    }

}
