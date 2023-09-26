using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int y;
	
	public bool hasKey;
    
    // Start is called before the first frame update
    void Start()
    {
        y = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex;
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        hasKey = false;
        Debug.Log("Level dsadsadasdsa finished");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("Enemy length 0");

           
            hasKey = true;
			if (y == 1)
			{

                (new NavigationController()).GoToVillageScene();



            }
            else if (y == 2)
			{
                (new NavigationController()).GoToForestScene();
            }
            else if (y == 3)
			{

                (new NavigationController()).GoToCastleScene();

            }
            else if (y == 4)
			{
                (new NavigationController()).GoToVictoryScene();

            }



            //
        }
    }
}
