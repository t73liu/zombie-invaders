using UnityEngine;

public class MusicLoader : MonoBehaviour {
	private static MusicLoader _instance;

	private void Awake()
	{
		Debug.Log("Awake MusicLoader " + GetInstanceID());
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
			print("Destroying Extra MusicLoader");
		}
	}

	// Use this for initialization
	private void Start()
	{
		Debug.Log("Start MusicLoader " + GetInstanceID());
	}
}
