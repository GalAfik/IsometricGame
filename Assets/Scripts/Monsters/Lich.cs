using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : Monster
{
	public float PlayerBackAwayDistance = 4f;
	public Projectile Projectile;
	public Transform ProjectileSpawnPoint;

	protected override void Move()
	{
		// Zero out velocity
		Velocity = Vector3.zero;

		// PlayerBackAwayDistance cannot be greater than PlayerFollowDistance
		Debug.Assert(PlayerBackAwayDistance < PlayerFollowDistance);
		// If the player is within the threshold distance
		Vector3 playerLatitude = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
		float distanceFromPlayer = Vector3.Distance(playerLatitude, transform.position);
		if (distanceFromPlayer <= PlayerBackAwayDistance)
		{
			// Move away from the player when they get close
			Velocity = -(playerLatitude - transform.position) * MoveSpeed * Time.deltaTime;
		}
		else if (distanceFromPlayer <= PlayerFollowDistance)
		{
			// Move toward the player when too far away
			Velocity = (playerLatitude - transform.position) * MoveSpeed * Time.deltaTime;
		}

		// Apply velocity
		Rigidbody.MovePosition(transform.position + Velocity);
	}

	protected override void Attack()
	{
		// Check if the player is in range
		Vector3 playerLatitude = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
		float distanceFromPlayer = Vector3.Distance(playerLatitude, transform.position);
		if (distanceFromPlayer <= PlayerFollowDistance && AttackTimer <= 0)
		{
			// Attack!
			if (Projectile != null)
			{
				Instantiate(Projectile, ProjectileSpawnPoint ?? transform);
			}

			// Reset the attack timer
			AttackTimer = Mathf.Max(0, Random.Range(AverageAttackFrequency - (AttackFrequencyRange/2), AverageAttackFrequency + (AttackFrequencyRange / 2)));
		}
	}

	protected override void Animate()
	{
		// Set the walking animation
		Animator?.SetFloat("Speed", Velocity.magnitude);

		// Flip the sprite to always face the player's direction
		bool flipX = (transform.position.x - FindObjectOfType<Player>().transform.position.x) < 0;
		transform.localScale = new Vector3((flipX ? -1 : 1), transform.localScale.y, transform.localScale.z);
	}
}
