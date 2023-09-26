using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayer;
    Interactable interactableObj;
    public Image interactImg;
    public Sprite defaultIcon;
    public Vector2 defaultIconSize;
    public Sprite defaultInteractIcon;
    public Vector2 defaultInteractIconSize; //Size along x and y

    
        void Start() { }
// In the Update() function, define a Raycast hit and write an if-condition checks if 
//the Raycast hit DOES in fact pierce through any game object on the Interactable
//layermask.
// If TRUE: 
// Check the ID of the Interactable.It it is null or a different
//number, assign the interactableObj variable to be this new
//Interactable object
// In the interaction icon is null, assign it an image that’s
//different from the default icon, so the player knows
//they’ve found something Interactable! Adjust size and
//make it green
// Check if player input left-mouse click.If true, invoke the
//Unity Event on the Interactable
// If FALSE: the mouse icon remains at default and nothing happens

 void Update()
 {
        RaycastHit hit;
        //Physics.ra
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 200f, interactableLayer))
        {   
            //Upon hitting any item with the script Interactable attached
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                if (interactableObj == null ||
                interactableObj.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactableObj = hit.collider.GetComponent<Interactable>();
                    Debug.Log("Detected");
                }


                if (interactableObj.interactIcon != null)
                {
                    interactImg.sprite = interactableObj.interactIcon;

                    Debug.Log("Not Detected");
                    if (interactableObj.iconSize == Vector2.zero)
                    {

                        interactImg.rectTransform.sizeDelta =
                        defaultInteractIconSize;
                    }
                    else
                    {
                        interactImg.rectTransform.sizeDelta = interactableObj.iconSize;
                        interactImg.color = Color.green;
                    }
                }
                else
                {

                    interactImg.sprite = defaultInteractIcon;

                    interactImg.rectTransform.sizeDelta =
                    defaultInteractIconSize;
                }

                if (Input.GetMouseButton(0)) //left mouse click
                {

                    interactableObj.onInteract.Invoke();

                }
            }
        }
        else
        {

            if (interactImg.sprite != defaultIcon)
            {
                interactImg.sprite = defaultIcon;
                interactImg.rectTransform.sizeDelta = defaultIconSize;
                interactImg.color = Color.red;
            }
        }
    } }
