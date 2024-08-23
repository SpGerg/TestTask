using Characters;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
    public static EnemiesPool Instance { get; private set; }

    [SerializeField]
    private GameObject _enemyCharacter;

    private readonly ConcurrentQueue<EnemyCharacter> _pool = new();

    public void Awake()
    {
        Instance = this;
    }

    public EnemyCharacter Get()
    {
        if (_pool.TryDequeue(out var character))
        {
            return character;
        }

        return Instantiate(_enemyCharacter, Vector3.zero, Quaternion.Euler(0, 90, 0)).GetComponentInChildren<EnemyCharacter>();
    }

    public void Return(EnemyCharacter enemyCharacter)
    {
        _pool.Enqueue(enemyCharacter);
    }
}
