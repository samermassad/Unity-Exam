using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyser : MonoBehaviour {

	private AudioSource _audioSource;
	private float[] _averages;
	private float _timeOfLastBeat = 0F;
	
	public int m_channels = 9;
	public int m_desiredChannel = 0;
	public float m_threshold = 0.1F;
	public float m_beatMargin = 0.2F;
	public float[] m_analysedData = new float[512];
	public bool is_beat = false;
	
	void Start () {
		_audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		is_beat = false;
		
		// get spectrum data
		_audioSource.GetSpectrumData(m_analysedData, 0, FFTWindow.Hanning);
		
		// clear the averages array
		_averages = new float[m_channels];
		_averages = AnalyserHelper.calculateAverages(m_analysedData);
		
		float timeSinceLastBeat = Time.time - _timeOfLastBeat;
		
		if(_averages[m_desiredChannel] > m_threshold && timeSinceLastBeat > m_beatMargin) {
			is_beat = true;
			_timeOfLastBeat = Time.time;
		}		
	}
}
