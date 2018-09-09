using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
	// Time to wait before restarting the level
	public float restartDelay = 5f;
	bool isDead;
	int playerHealth;



	float restartTimer;                     // Timer to count up to restarting the level




	void Update()
	{

		// If the player has run out of health...
		if (isDead == true) 
		{
			// ... tell the animator the game is over.
			//("GameOver");

			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;

			// .. if it reaches the restart delay...
			if (restartTimer >= restartDelay)
			{
				// .. then reload the currently loaded level.
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		
	}
	
}
	
