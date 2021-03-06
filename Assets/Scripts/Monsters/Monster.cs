﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour
{
	public int Damage = 1;

	public float MoveSpeed;
	protected Vector3 Velocity;
	public float PlayerFollowDistance = 2f;

	public int AveragePointValue = 5;
	public int PointValueMultiplier = 10;
	public TMP_Text PointLabel;
	public int PointValue { get; private set; }

	public float AverageAttackFrequency = 5f;
	public float AttackFrequencyRange = 2f;
	protected float AttackTimer = 0;

	protected Player Player;
	protected Rigidbody Rigidbody;
	protected Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
		// Get components
		Animator = GetComponent<Animator>();
		Player = FindObjectOfType<Player>();
		Rigidbody = GetComponent<Rigidbody>();

		// Set the point value and label
		int min = Mathf.Max(0, AveragePointValue - 2);
		PointValue = Random.Range(min, AveragePointValue + 2) * PointValueMultiplier;
		PointLabel?.SetText("+" + PointValue);

		// Start the Idle animation on a random frame to vary monster animations
		AnimatorStateInfo state = Animator.GetCurrentAnimatorStateInfo(0);
		Animator.Play(state.fullPathHash, -1, Random.Range(0f, 1f));

		// Reset the attack timer
		AttackTimer = AverageAttackFrequency;
	}

    // Update is called once per frame
    void Update()
    {
		// Handle movement
		Move();
		
		// Handle Attacking
		Attack();
		// Work the attack timer
		if (AttackTimer > 0) AttackTimer -= Time.deltaTime;

		// Handle animations
		Animate();
    }

	protected virtual void Move()
	{
		// Zero out velocity
		Velocity = Vector3.zero;

		// If the player is within the threshold distance
		Vector3 playerLatitude = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
		if (Vector3.Distance(playerLatitude, transform.position) <= PlayerFollowDistance)
		{
			// Move towards the player
			Velocity = (playerLatitude - transform.position) * MoveSpeed * Time.deltaTime;
		}

		// Apply velocity
		Rigidbody.MovePosition(transform.position + Velocity);
	}

	protected virtual void Attack() { }

	protected virtual void Animate()
	{
		// Set the walking animation
		Animator?.SetFloat("Speed", Velocity.magnitude);

		// Flip the sprite to match the walking direction
		if (Velocity.x > 0) GetComponentInChildren<SpriteRenderer>().flipX = true;
		else GetComponentInChildren<SpriteRenderer>().flipX = false;
	}

	private IEnumerator OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Weapon"))
		{
			// Set the death animation
			Animator?.SetTrigger("Dead");

			// Add points
			FindObjectOfType<Game>().SetPoints(FindObjectOfType<Game>().GetPoints() + PointValue);
			// Immediately destroy the collider
			Destroy(GetComponent<Collider>());

			// Wait a few seconds before destroying this object
			yield return new WaitForSeconds(3f);
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			// Damage the player
			Player.SetHealth(Player.GetHealth() - Damage);
		}
	}
}
