using UnityEngine;

public class Castle : MonoBehaviour
{
    public Projectile Projectile;

    private Transform _target;
    private int _enemyLayerMask;
    private float _currentCooldown;
    
    const float _maxCooldown = 0.8f;


    void Start()
    {
        this._enemyLayerMask = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        AcquireTargetIfNecessary();
        TryAttack();
    }

    void AcquireTargetIfNecessary()
    {
        if (this._target == null)
        {
            this._target = Physics2D.OverlapCircle(this.transform.position, 5f, this._enemyLayerMask)?.transform;
        }
    }

    void TryAttack()
    {
        _currentCooldown -= Time.deltaTime;
        if (this._target == null || !(_currentCooldown <= 0f)) return;
        this._currentCooldown = _maxCooldown;
        Attack();
    }

    void Attack()
    {
        Instantiate(this.Projectile, this.transform.position, GetTargetDirection());
    }

    Quaternion GetTargetDirection()
    {
        var dir = this._target.transform.position - this.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
}