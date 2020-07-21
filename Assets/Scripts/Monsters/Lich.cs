using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : Monster
{
	public float PlayerBackAwayDistance = 4f;

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

	protected override void Animate()
	{
		// Set the walking animation
		Animator?.SetFloat("Speed", Velocity.magnitude);

		// Flip the sprite to always face the player's direction
		GetComponentInChildren<SpriteRenderer>().flipX = (transform.position.x - FindObjectOfType<Player>().transform.position.x) < 0;
	}
}
