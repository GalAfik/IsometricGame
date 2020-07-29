using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Health))]

public class Player : MonoBehaviour
{
	public float MoveSpeed = 1f;
	public float RunSpeed = 2f;
	private float CurrentVerticalSpeed;
	private Vector3 Velocity;
	private bool RunningEnabled = false;

	private CharacterController Controller;
	private Animator Animator;

	public float AttackDelayTime = .5f;
	private float AttackTimer = 0;
	public Weapon Weapon;
	private Animator WeaponAnimator;

    // Start is called before the first frame update
    void Start()
    {
		// Get components
		Controller = GetComponent<CharacterController>();
		Animator = GetComponent<Animator>();

		// Get the weapon animator
		WeaponAnimator = Weapon?.gameObject.GetComponentInChildren<Animator>();

		// Zero out the movement velocity
		Velocity = Vector3.zero;
		CurrentVerticalSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
		// Handle movement
		Move();
		// Handle Attacking
		Attack();
		// Handle animations
		Animate();
	}

	void Move()
	{
		// Handle horizontal velocity
		Velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		// Apply horizontal velocity vector
		Controller.Move(Velocity * (RunningEnabled ? RunSpeed : MoveSpeed) * Time.deltaTime);

		// Handle gravity
		if (Controller.isGrounded) CurrentVerticalSpeed = 0f;
		else CurrentVerticalSpeed += Physics.gravity.y * Time.deltaTime;
		Vector3 VerticalVelocity = new Vector3(0, CurrentVerticalSpeed, 0);
		// Apply vertical velocity vector
		Controller.Move(VerticalVelocity * MoveSpeed * Time.deltaTime);
	}

	void Attack()
	{
		// Make sure the weapon is facing the right way (fixed for inverted animation direction)
		if (Velocity != Vector3.zero) Weapon.transform.forward = -Velocity.normalized;
		// Play the attack animation
		if (Input.GetButtonDown("Attack") && AttackTimer <= 0)
		{
			WeaponAnimator?.SetTrigger("Attack");
			// Set the Attack delay timer
			AttackTimer = AttackDelayTime;
		}
		// Count down the attack delay counter
		if (AttackTimer >= 0) AttackTimer -= Time.deltaTime;
	}

	void Animate()
	{
		Animator?.SetFloat("HorizontalSpeed", Velocity.x);
		Animator?.SetFloat("VerticalSpeed", Velocity.z);

		if (RunningEnabled)
		{
			// Double the movement animation speed when running
			Animator.speed = RunSpeed / MoveSpeed;
		}
		else Animator.speed = 1f;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("WalkZone")) RunningEnabled = false;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("WalkZone")) RunningEnabled = true;
	}

	public int GetHealth() { return GetComponent<Health>().CurrentHealth; }
	public int GetMaxHearts() { return GetComponent<Health>().MaxHearts; }

	public void SetHealth(int health)
	{
		// Make sure health never goes below zero
		if (health < 0) health = 0;
		GetComponent<Health>().CurrentHealth = health;
	}
}
