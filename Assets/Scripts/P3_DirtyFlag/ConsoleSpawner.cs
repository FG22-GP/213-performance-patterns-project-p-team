using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConsoleSpawner : MonoBehaviour
{
    public Console ConsolePrefab;
    private float _currentCooldown;
    
    const float _totalCooldown = 0.2f;
    
    void FixedUpdate()
    {
        this._currentCooldown -= Time.deltaTime;
        if (this._currentCooldown <= 0f)
        {
            this._currentCooldown += _totalCooldown;
            SpawnConsole();
        }
    }

    void SpawnConsole()
    {
        var randomPositionX = Random.Range(-6f, 6f);
        var randomPositionY = Random.Range(-6f, 6f);
        Instantiate(this.ConsolePrefab, new Vector2(randomPositionX, randomPositionY), Quaternion.identity);
    }
}
