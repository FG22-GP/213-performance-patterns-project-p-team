using System;
using UnityEngine;
using Object = UnityEngine.Object;

[RequireComponent(typeof(ObjectPool))] public class Castle : MonoBehaviour {

	public Projectile Projectile;
	public ObjectPool PoolRef;

	private Transform _target;
	private int _enemyLayerMask;
	private float _currentCooldown;

	const float _maxCooldown = 0.8f;
	private void Awake() => PoolRef = GetComponent<ObjectPool>();

	void Start() {
		this._enemyLayerMask = LayerMask.GetMask("Enemy");
	}

	// Update is called once per frame
	void Update() {
		AcquireTargetIfNecessary();
		TryAttack();
	}

	void AcquireTargetIfNecessary() {
		if (this._target == null) {
			this._target = Physics2D.OverlapCircle(this.transform.position, 5f, this._enemyLayerMask)?.transform;
		}
	}

	void TryAttack() {
		_currentCooldown -= Time.deltaTime;
		if (this._target == null || !(_currentCooldown <= 0f)) return;
		this._currentCooldown = _maxCooldown;
		Attack();
	}

	void Attack() {
		Projectile tempProjectile = PoolRef.Pool.Get();
		Transform transformRef;
		(transformRef = tempProjectile.transform).rotation = GetTargetDirection();
		transformRef.position = this.transform.position;
	}

	Quaternion GetTargetDirection() {
		var dir = this._target.transform.position - this.transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
		return Quaternion.AngleAxis(angle, Vector3.forward);
	}

}