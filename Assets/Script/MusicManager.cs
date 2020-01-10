using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	
	private static MusicManager instance = null;
	
	public MusicManager Instance()
	{
		return instance;
	}
	
	public void Awake()
	{
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		}
		else
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
