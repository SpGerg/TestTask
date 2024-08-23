using Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform _spawn;

    private int _spawnedEnemiesCount;

    public void Start()
    {
        BasicHealth.Died.AddListener(SpawnEnemyOnDied);

        StartCoroutine(SpawnEnemiesCoroutine());
    }

    public void OnDisable()
    {
        BasicHealth.Died.RemoveListener(SpawnEnemyOnDied);
    }

    public void SpawnEnemy()
    {
        if (_spawnedEnemiesCount > 3)
        {
            return;
        }

        var enemy = EnemiesPool.Instance.Get();
        enemy.Damageable.Health = enemy.Damageable.MaxHealth;
        enemy.gameObject.SetActive(true);

        enemy.transform.position = _spawn.position;

        _spawnedEnemiesCount++;
    }

    private void SpawnEnemyOnDied(Character character)
    {
        if (character is not EnemyCharacter)
        {
            return;
        }

        _spawnedEnemiesCount--;

        SpawnEnemy();
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        for (; _spawnedEnemiesCount < 3; _spawnedEnemiesCount++)
        {
            yield return new WaitForSeconds(1);

            SpawnEnemy();
        }
    }
}