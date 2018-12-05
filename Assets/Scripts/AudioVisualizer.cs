using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour {
	
	public GameObject m_primaryAnalyser;
	public GameObject m_secondaryAnalyser;
	public static List<GameObject> m_redLaserShooters = new List<GameObject>();
	public static List<GameObject> m_greenLaserShooters = new List<GameObject>();
	public float m_beatMargin = 0.1F;
	
	void Start () {
		
	}
	
	void Update () {
		if(m_secondaryAnalyser.GetComponent<AudioAnalyser>().is_beat) {
			foreach(GameObject shooter in m_greenLaserShooters) {
				shooter.GetComponent<LaserShooterController>().Shoot();
			}
		}
		
		if(m_primaryAnalyser.GetComponent<AudioAnalyser>().is_beat) {
			foreach(GameObject shooter in m_redLaserShooters) {
				shooter.GetComponent<LaserShooterController>().Shoot();
			}
		}
	}
}
