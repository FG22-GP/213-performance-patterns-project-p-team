using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Castle _castle;
    
    void Start()
    {
        this._castle = GameObject.FindWithTag("Player").GetComponent<Castle>();
        FakeSetUpEnemy();
    }

    /// <summary>
    /// Setting up complex Prefabs containing Models, Sprites, Materials etc.
    /// Is Expensive. This Call simulates a more complex Object.
    /// Do not remove this Method invocation from Start.
    /// Instead, try to avoid `Start` being invoked in the first place. 
    /// </summary>
    void FakeSetUpEnemy()
    {
        Thread.Sleep(25);
    }

    // Update is called once per frame
    void Update()
    {
        WalkTowardsCastle();
        LookAtCastle();
    }

    void WalkTowardsCastle()
    {
        var current = this.transform.position;
        var target = _castle.transform.position;
        this.transform.position = Vector3.MoveTowards(current, target, Time.deltaTime);
    }

    void LookAtCastle()
    {
        var current = this.transform.position;
        var target = _castle.transform.position;
        var dir = target - current;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollision!");
        Destroy(this.gameObject);
    }
}
