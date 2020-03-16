using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public int level;

	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Loading Level");
		SceneManager.LoadScene(level);
	}
}
