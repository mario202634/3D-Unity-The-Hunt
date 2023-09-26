using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

 public class HintManager : MonoBehaviour
 {
 public TextMeshProUGUI textDisplay; //a special variable that holds the TextMeshPro - Text for manipulation
 private string dialogueSentence; //a string that stores all the sentences if key is NOT found
 private int index = 0; 
 public float typingSpeed; //a variable to control the speed of the typewriter effect
 public GameObject HintBox; //a variable that holds the panel(dialogue box)
 public Rigidbody playerRB; //a variable that holds the player's/character's Rigidbody2D component

 void Start()
 {
 //Normally, the dialogue box is disabled unless a hint is triggered
 HintBox.SetActive(false);
 }

 //IEnumerator is a special type of function where the help of the StartCoroutine() function, the 
 //IEnumerator can be paused and resumed for a amount of time without pausing the game itself.
 //The purpose of this particular function is to display the hint with a typewriter effect
 public IEnumerator TypeDialogue()
 {
 HintBox.SetActive(true); //enables the dialogue box
    foreach (char letter in
    dialogueSentence.ToCharArray()) //converting the sentence to an array of char to loop through each char
         {
 textDisplay.text += letter; //adding each char to the text displayed on HUD

        yield return new WaitForSeconds(typingSpeed);
        //this special type of return is used with the IEnumerator and StartCoroutine() function
 //to pause the execution of this (TypeDialogue) for the specified (typingSpeed) amount of seconds, then after this amount
 //of seconds has passed this function (TypeDialogue)continues its exectution

 if (textDisplay.text == dialogueSentence)
//checks if the whole sentence has been printed
 {
 yield return new WaitForSeconds(2f);
 textDisplay.text = ""; //clear the displayed text after 2 seconds

 HintBox.SetActive(false); //disable the dialogue box
 this.dialogueSentence = null; //clear the sentence
 index = 0; //reset the index
 }
 }
 }

 public void SetSentence(string sentence) //sets the sentence to the passed from another game object
 {
 this.dialogueSentence = sentence;
 }
 }
