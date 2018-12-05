using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnalyserHelper {
		
	public static float[] calculateAverages(float[] analysedData) {
		int previousLog = 0;
		int channels = (int)Mathf.Floor(Mathf.Log(analysedData.Length,2));
		float[] averages = new float[channels];
		for(int i = 0 ; i < analysedData.Length; i++) {
			// if log2(i) > previous i => new bar
			int log = (int)Mathf.Floor(Mathf.Log(i,2));
			if(log > previousLog) {
				previousLog = log;
				averages[previousLog] = 0;
			} else {
				averages[previousLog] += analysedData[i];
			}
		}
		return averages;
	}
	
}
