using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	//Code Found at http://answers.unity3d.com/questions/936316/how-to-flash-screen-color-in-unity-5.html

	float _timeElapsed;
	float _totalTime;

	public Timer(float timeToCountInSec){
		_totalTime = timeToCountInSec;
	}

	public bool UpdateAndTest(){
		_timeElapsed+= Time.deltaTime;
		return _timeElapsed>=_totalTime;
	}

	public float Elapsed{
		get {return Mathf.Clamp(_timeElapsed/_totalTime,0,1);}
	}
}
