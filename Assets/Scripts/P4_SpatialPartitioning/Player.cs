using System.Threading;
using UnityEngine;
using Input = UnityEngine.Input;

public class Player : MonoBehaviour
{
    private Camera _cam;

    void Start()
    {
        this._cam = Camera.main;
    }
    
    void Update()
    {
        // Place Player under Cursor
        var position = this._cam.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        transform.position = position;
        
        // Find closest Car
        var closestCar = FindClosestCar();
        if (closestCar == null) return;
        
        // If found, point towards the car
        var dir = closestCar.transform.position - this.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    GameObject FindClosestCar()
    {
        var allCars = GameObject.FindGameObjectsWithTag("Car");
        GameObject closestCar = null;
        float distance = float.PositiveInfinity;
        
        // Problem: We need to check all cars in the scene to find the closest one.
        foreach (var car in allCars)
        {
            var currentDistance = CalculateDistanceTo(car.transform);
            if (currentDistance < distance)
            {
                distance = currentDistance;
                closestCar = car;
            }
        }

        return closestCar;
    }

    float CalculateDistanceTo(Transform target)
    {
        // DO NOT REMOVE, THIS IS TO EXAGGERATE THE EFFECT OF CALCULATING VECTOR DISTANCES
        Thread.Sleep(1);
        return Vector3.Distance(target.position, this.transform.position);
    }
}
