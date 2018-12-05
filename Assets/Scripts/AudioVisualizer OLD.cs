using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizerOLD : MonoBehaviour {

	private GameObject[] _objects = new GameObject[512];
	private GameObject[] _bars;
	private float[] _averages;
	//private float _tempo = 99999F;
	private float _timeOfLastBeat = 0F;
	//private float _timer = 0;
	
	//private float nextActionTime = 0.0f;
	//private float period = 0.2f;
	private BeatAnalyser beatAnalyser;
	
	public GameObject m_primaryAnalyser;
	public GameObject m_secondaryAnalyser;
	public GameObject m_cubeModel;
	public GameObject m_barModel;
	public static List<GameObject> m_redLaserShooters = new List<GameObject>();
	public static List<GameObject> m_greenLaserShooters = new List<GameObject>();
	public float m_redThreshold = 0.1F;
	public float m_greenThreshold = 0.07F;
	public float m_beatMargin = 0.1F;
	public int m_radius = 50;
	public int m_amplifingValue = 300;
	
	void setBar(int barNumber) {
		GameObject bar = _bars[barNumber];
		Vector3 oldSize = _bars[barNumber].transform.localScale;
		Vector3 newSize = oldSize;
		if(barNumber == 0) {
			newSize.y = _averages[barNumber] * 20;
		} else {
			newSize.y = _averages[barNumber] * 20 / Mathf.Pow(barNumber, 2);
		}
		//bar.transform.localScale = newSize;
		bar.transform.localScale = Vector3.Lerp(oldSize, newSize, Time.time);
	}
	
	void Start () {
		//_bars = new GameObject[(int)Mathf.Floor(Mathf.Log(_objects.Length, 2))];
		
		//int previousLog = -1;
		
		//for(int i = 0 ; i < _objects.Length; i++) {
			// cube
			//float angle = i * Mathf.PI * 2 / _objects.Length;
			//Vector3 pos = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * m_radius;
			
			//GameObject g = Instantiate( m_cubeModel, pos, Quaternion.identity );
			//g.transform.parent = transform;
			//g.name = "Visualizer Cude: " + i;
			//_objects[i] = g;
			
			// bar
			// if log2(i) > previous i => new bar
			//int log = (int)Mathf.Floor(Mathf.Log(i,2));
			//if(log > previousLog) {
			//	previousLog = log;
			//	//float angleBars = previousLog * Mathf.PI * 2 / _bars.Length;
			//	//Vector3 posBar = new Vector3(Mathf.Cos(angleBars), 0f, Mathf.Sin(angleBars)) * m_radius / 2;
			//	Vector3 posBar = new Vector3(2*previousLog, 0f, 0f);
			//	GameObject b = Instantiate( m_barModel, posBar, Quaternion.identity );
			//	b.transform.parent = transform;
			//	b.name = "Visualizer Bar: " + previousLog;
			//	_bars[previousLog] = b;
			//}
		//}
		
	}
	
	void Update () {
		//_averages = new float[(int)Mathf.Floor(Mathf.Log(_objects.Length, 2))];
		//float[] m_analysedData = AudioAnalyser.m_analysedData;
		//int previousLog = 0;
		//for(int i = 0 ; i < m_analysedData.Length; i++) {
			// cube
			//Vector3 oldPos = _objects[i].transform.position;
			//oldPos.y = m_analysedData[i] * m_amplifingValue;
			//_objects[i].transform.position = oldPos;
			
			// bar
			// bar
			// if log2(i) > previous i => new bar
		//	int log = (int)Mathf.Floor(Mathf.Log(i,2));
		//	if(log > previousLog) {
		//		setBar(previousLog);
		//		previousLog = log;
		//		_averages[previousLog] = 0;
		//	} else {
		//		_averages[previousLog] += m_analysedData[i];
		//	}
		//}
		//setBar(previousLog);
		
		if(m_secondaryAnalyser.GetComponent<AudioAnalyser>().is_beat) {
			foreach(GameObject shooter in m_greenLaserShooters) {
				shooter.GetComponent<LaserShooterController>().Shoot();
			}
		}
		
		if(m_primaryAnalyser.GetComponent<AudioAnalyser>().is_beat) {
			foreach(GameObject shooter in m_redLaserShooters) {
				shooter.GetComponent<LaserShooterController>().Shoot();
			}
			
			//set the tempo
		//	float currentTime = Time.time;
		//	float deltaTime = Time.deltaTime;
			
		//	float expectedTempo = currentTime - _timeOfLastBeat;
		//	if(expectedTempo < _tempo && expectedTempo > m_beatMargin) {
		//		_tempo = expectedTempo;
		//		Debug.Log("Tempo calibrated!");
		//		_timer = _tempo;
		//		nextActionTime = _tempo;
		//	}
		//	Debug.Log("Tempo: " + _tempo);
		//	_timeOfLastBeat = currentTime;
			
		}
		
		//if (Time.time > nextActionTime ) {
		//	nextActionTime += _tempo;
		//	foreach(GameObject shooter in m_greenLaserShooters) {
		//		shooter.GetComponent<LaserShooterController>().Shoot();
		//	}
		//}
		 
		//_timer -= Time.deltaTime;
		//	if(_timer <= 0) {
		//		foreach(GameObject shooter in m_greenLaserShooters) {
		///			shooter.GetComponent<LaserShooterController>().Shoot();
		//		}
		//		_timer = _tempo;
		//	}
		
		//float timeSinceLastBeat = Time.time - _timeOfLastBeat;
		//Debug.Log("Average: " + _averages[4] + " Time since last beat: " + timeSinceLastBeat);
		//if(_averages[4] > m_greenThreshold) {
		//	if(timeSinceLastBeat > m_beatMargin) {
		//		Debug.Log("Fire!");
		//		foreach(GameObject shooter in m_greenLaserShooters) {
		//			shooter.GetComponent<LaserShooterController>().Shoot();
		//		}
		//		_timeOfLastBeat = Time.time;
		//	} else {
		//		Debug.Log("Beat margin is not done!");
		//	}
		//} else {
		//	Debug.Log("Average is less than trigger!");
		//}
	}
}
