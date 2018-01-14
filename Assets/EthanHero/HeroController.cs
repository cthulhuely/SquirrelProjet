using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// We ask some Data to get the script working
[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(CapsuleCollider))]
[RequireComponent (typeof(Animator))]
public class HeroController : MonoBehaviour
{

	// Data get from the asset on the scene
	Rigidbody m_Rigidbody;
	// We get the rigid body use to move the Hero
	Animator m_Animator;
	// The animator to tell witch animation must run
	CapsuleCollider m_Capsule;
	// The capsule collider used to get the hitbox (if the hero hit the ground)

	// Private data

	// Here were goin to get Ethan to walk on left or right

	/////////////////////////
	// Movement
	private bool isMovingLeft = false;
	private bool isMovingRight = false;

	// A serializeField is an writable flied from the inspector view
	[SerializeField] int velocityX = 10;

	/////////////////////////

	// Use this for initialization
	void Start ()
	{
		// Get value from autolink
		m_Animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();
		m_Capsule = GetComponent<CapsuleCollider>();

		// Init RigidBody
		this.m_Rigidbody.velocity = new Vector3 (0, 0, 0); // Idle
		// Can only move X, no rotation XYZ no movement YZ
		m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

		// Animator
		this.m_Animator.speed = 1;
		this.m_Animator.Play ("Grounded");
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.isMovingLeft = Input.GetKey (KeyCode.LeftArrow);
		this.isMovingRight = Input.GetKey (KeyCode.RightArrow);


		ProcessMovement ();
	}

	void ProcessMovement ()
	{
		if (this.isMovingLeft == this.isMovingRight) { // Both are true or both are false			
			this.m_Rigidbody.velocity = new Vector3 (0, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z); // We stop
			return;
		}


		if (this.isMovingLeft) {
			this.m_Rigidbody.velocity = new Vector3 (-velocityX,  m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
		} else {
			this.m_Rigidbody.velocity = new Vector3 (velocityX,  m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
		}

	}
}
