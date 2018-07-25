using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TouchToWin : MonoBehaviour 
{

	void Start () 
	{
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag == ("Player"))
		{
			SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
		}
	}
}
