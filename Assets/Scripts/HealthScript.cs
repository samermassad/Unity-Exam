using UnityEngine;
using System.Collections.Generic;

public class HealthScript : MonoBehaviour {

	public int m_health = 100;
	public GameObject m_player;
	private int m_currentHealth;


	void Start() {
		m_currentHealth = m_health;
	}
	
	void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Health: " + m_currentHealth);
    }
	
	private void OnTriggerEnter(Collider other) {
		if(other.tag == "RedLaser") {
			m_currentHealth -= 40;
		}
		if(other.tag == "GreenLaser") {
			m_currentHealth -= 20;
		}
		if(m_currentHealth <= 0) {
			m_currentHealth = m_health;
			Vector3 zero = new Vector3();
			zero.x = 0f;
			zero.y = 0f;
			zero.z = -43.79f;
			
			m_player.transform.position = zero;
		}
	}
}
