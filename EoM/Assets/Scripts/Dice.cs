using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;                         // Array of dice sides sprites to load from Resources folder
    private SpriteRenderer rend;                        // Reference to sprite renderer to change sprites
    public GameControl controller;
    public FollowThePath move;
	public PlayerAttributes changeAttributes;
    
    private void Start ()                               // Use this for initialization
	{
        rend = GetComponent<SpriteRenderer>();          // Assign Renderer component
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
    }
	
    
    
    
    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }



    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        //Debug.Log("sds");
        int randomDiceSide = 0;             // Variable to contain random dice side number
        int finalSide = 0;                  // Final side or value that dice reads in the end of coroutine
    
        for (int i = 0; i <= 20; i++)       // Loop to switch dice sides ramdomly
        {
            randomDiceSide = Random.Range(0, 5);            // Pick up random value from 0 to 5 (All inclusive)
            rend.sprite = diceSides[randomDiceSide];        // Set sprite to upper face of dice from array according to random value
            yield return new WaitForSeconds(0.05f);         // Pause before next itteration
        }

        finalSide = randomDiceSide + 1;
        controller.diceSideThrown = finalSide;          // Assigning final side

        Debug.Log(finalSide);                           // Show final dice value in Console
        controller.MovePlayer();
        changeAttributes.updateAttributes();

    }
}
