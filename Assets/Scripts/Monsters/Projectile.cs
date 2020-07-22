using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
{
	public int Damage = 2;
	public float DestroyDistance = 10f;
	public float MoveSpeed = 1f;
	protected Vector3 Velocity;

	protected Player Player;

	// Start is called before the first frame update
	void Start()
	{
		// Detach from any other object
		transform.parent = null;

		// Get components
		Player = FindObjectOfType<Player>();

		// Set the target velocity - move towards the player
		Velocity = Player.transform.position - transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		// Handle movement
		Move();
	}

	protected virtual void Move()
	{
		// Apply velocity
		transform.position += Velocity.normalized * MoveSpeed * Time.deltaTime;

		// Destroy this object when it gets suffieciently far away from the player
		if ((transform.position - Player.transform.position).magnitude >= DestroyDistance)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// Damage the player
			Player.SetHealth(Player.GetHealth() - Damage);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		// Destroy this object
		Destroy(gameObject);
	}
}
