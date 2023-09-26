using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHint : MonoBehaviour
{
    public HintManager hintManager; //a variable that stores the Dialogue script that is attached to the Dialogue Manager gameobject
    public LevelManager levelm;
    string dialogueOption1 = "Excersice arena , use the left click mouse button to attack the targets.";
    string dialogueOption2 = ".";
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (levelm.hasKey == false)
            {
                Debug.Log("No Key");
                hintManager.SetSentence(dialogueOption1); //set sentences in case of failing to find key
            hintManager.StartCoroutine(hintManager.TypeDialogue());
                //start the coroutine of TypeDialogue(), which in turn starts sentences sequentially
            }
            else if (levelm.hasKey == true)
            {
                Debug.Log("Has Key");
                hintManager.SetSentence(dialogueOption2); //set the sentences in case of successfully finding key
            hintManager.StartCoroutine(hintManager.TypeDialogue());
            }
        }
    }

}
