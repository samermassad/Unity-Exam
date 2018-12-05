using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public float m_speed;
	public int m_health = 9;
	public float m_rotateSpeed = 1.0F;
	
	private Animator _animator;
	
	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Rotate();
	}
	
	private void Move() {
		//Vector3 newPos = Vector3.zero;
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");
		//newPos *= m_speed;
		//newPos *= Time.deltaTime;
		
		//this.transform.position += newPos;
		
		float forwardSpeed = 0;
		if(vertical > 0) {
			forwardSpeed = m_speed;
		} else if(vertical < 0) {
			forwardSpeed = -m_speed;
		}
		_animator.SetFloat("MoveSpeed", forwardSpeed);
		//transform.position += transform.forward * Time.deltaTime * forwardSpeed;
	}
	
	private void Rotate() {
		if(Input.GetAxis("Mouse X") > 0)
			transform.Rotate(Vector3.up * m_rotateSpeed);
		if(Input.GetAxis("Mouse X") < 0)
			transform.Rotate(Vector3.up * -m_rotateSpeed);
	}
	
	private void OnTriggerEnter(Collider other) {
		if(other.tag == "EnemyBullet") {
			m_health -= 10;
		}
		if(m_health <= 0) {
			Destroy(other.gameObject);
			m_health = 9;
			Vector3 zero = new Vector3();
			zero.x = -4.06f;
			zero.y = 0.17f;
			zero.z = -4.23f;
			
			this.transform.position = zero;
		}
	}
}
