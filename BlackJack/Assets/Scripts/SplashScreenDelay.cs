using UnityEngine;
using System.Collections;

public class SplashScreenDelay : MonoBehaviour {
    public float DelayTime = 5;
	
	IEnumerator Start () {
        yield return new WaitForSeconds(DelayTime);

        Application.LoadLevel("Main");
	}
	
}
