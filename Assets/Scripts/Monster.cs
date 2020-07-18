using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
	public float MoveSpeed;
	private Vector3 Velocity;
	public float PlayerFollowDistance = 2f;

	private Player Player;
	private Rigidbody Rigidbody;
	private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
		// Get components
		Animator = GetComponent<Animator>();
		Player = FindObjectOfType<Player>();
		Rigidbody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
		// Handle movement
		Move();
		// Handle animations
		Animate();
    }

	void Move()
	{
		// Zero out velocity
		Velocity = Vector3.zero;

		// If the player is within the threshold distance
		Vector3 PlayerLatitude = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
		if (Vector3.Distance(PlayerLatitude, transform.position) <= PlayerFollowDistance)
		{
			// Move towards the player
			Velocity = (PlayerLatitude - transform.position) * MoveSpeed * Time.deltaTime;
		}

		// Apply velocity
		Rigidbody.MovePosition(transform.position + Velocity);
	}

	void Animate()
	{
		// Set the walking animation
		Animator?.SetFloat("Speed", Velocity.magnitude);

		// Flip the sprite to match the walking direction
		if (Velocity.x > 0) GetComponentInChildren<SpriteRenderer>().flipX = true;
		else GetComponentInChildren<SpriteRenderer>().flipX = false;
	}

	private IEnumerator OnTriggerEnter(Collider other)
	{
		print(other.name);
		if (other.CompareTag("Weapon"))
		{
			// Set the death animation
			Animator?.SetTrigger("Dead");
			// Wait a few seconds before destroying this object
			yield return new WaitForSeconds(3f);
			Destroy(gameObject);
		}
	}
}
