using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : Monster
{
	protected override void Move()
	{
		// Zero out velocity
		Velocity = Vector3.zero;

		// If the player is within the threshold distance
		Vector3 PlayerLatitude = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
		if (Vector3.Distance(PlayerLatitude, transform.position) <= PlayerFollowDistance)
		{
			// Move away from the player when they get close
			Velocity = -(PlayerLatitude - transform.position) * MoveSpeed * Time.deltaTime;
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
