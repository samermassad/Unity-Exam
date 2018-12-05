using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooterController : MonoBehaviour {
	
	private GameObject _laser;
	
	public void Shoot() {
		StartCoroutine(_Shoot());
	}
	
	// Use this for initialization
	void Start () {
		foreach(Transform child in transform)
		{
			if(child.tag == "RedLaser") {
				_laser = child.gameObject;
				AudioVisualizer.m_redLaserShooters.Add(this.gameObject);
				break;
			} else if(child.tag == "GreenLaser") {
				_laser = child.gameObject;
				AudioVisualizer.m_greenLaserShooters.Add(this.gameObject);
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	private IEnumerator _Shoot() {
		_laser.SetActive(true);
		yield return new WaitForSeconds(0.05F);
		_laser.SetActive(false);
	}
}
