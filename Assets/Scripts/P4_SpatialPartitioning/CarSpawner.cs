using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    public Car CarPrefab;
    private float _currentCooldown;
    
    const float _totalCooldown = 0.2f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        this._currentCooldown -= Time.deltaTime;
        if (this._currentCooldown <= 0f)
        {
            this._currentCooldown += _totalCooldown;
            SpawnCar();
        }
    }

    void SpawnCar()
    {
        var randomPositionX = Random.Range(-60f, 60f);
        var randomPositionY = Random.Range(-60f, 60f);
        Instantiate(this.CarPrefab, new Vector2(randomPositionX, randomPositionY), Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }
}
