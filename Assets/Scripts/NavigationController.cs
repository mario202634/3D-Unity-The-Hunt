using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavigationController : MonoBehaviour
{
	public void GoToIntroScene()
	{
		Application.LoadLevel(0);
	}

	public void GoToArenaScene()
	{
		Application.LoadLevel(1);
	}

	public void GoToVillageScene()
	{
		Application.LoadLevel(2);
	}

	public void GoToForestScene()
	{
		Application.LoadLevel(3);
	}

	public void GoToCastleScene()
	{
		Application.LoadLevel(4);
	}

	public void GoToVictoryScene()
	{
		Application.LoadLevel(5);
	}

	public void GoToGameOverScene()
	{
		Application.LoadLevel(6);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
