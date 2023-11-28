using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour {

	private float _totalTime;

	private ObjectPool<Projectile> _poolRef;
	public void SetPool(ObjectPool<Projectile> pool) => _poolRef = pool;
	
	/// <summary>
	/// Setting up complex Prefabs containing Models, Sprites, Materials etc.
	/// Is Expensive. This Call simulates a more complex Object.
	/// Do not remove this Method invocation from Start.
	/// Instead, try to avoid `Start` being invoked in the first place. 
	/// </summary>
	void FakeInitializeProjectile() {
		//Thread.Sleep(100);
	}

	// Update is called once per frame
	void Update() {
		this._totalTime += Time.deltaTime;
		this.transform.Translate(Vector3.up * Time.deltaTime);
		if (this._totalTime > 10f) {
			_poolRef.Release(this);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		_poolRef.Release(this);
	}

}