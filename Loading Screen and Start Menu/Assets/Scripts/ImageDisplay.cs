using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageDisplay : MonoBehaviour {
	public Texture imageToDisplay;
	public float timeToDisplayImage;
	public int nextLevelToLoad;

	private float timeForNextLevel;

	public void Start() {
		timeForNextLevel = Time.time + timeToDisplayImage;
	}

	public void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), imageToDisplay);
		if (Time.time >= timeForNextLevel) {
			SceneManager.LoadScene(nextLevelToLoad);
		}
	}
}