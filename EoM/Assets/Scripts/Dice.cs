using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;                         // Array of dice sides sprites to load from Resources folder
    private SpriteRenderer rend;                        // Reference to sprite renderer to change sprites
    public GameControl controller;
	public Player1Attributes changeAttributesOf1;
    public Player2Attributes changeAttributesOf2;
    public int finalSide;

    public AudioSource diceMove,playerMove;

    private void Start ()                               // Use this for initialization
	{
        rend = GetComponent<SpriteRenderer>();          // Assign Renderer component
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        finalSide=0;
    }
	
    
    
    
    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        diceMove.Play();
        StartCoroutine("RollTheDice");
    }



    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        //Debug.Log("sds");
        int randomDiceSide = 0;             // Variable to contain random dice side number
                                          // Final side or value that dice reads in the end of coroutine
    
        for (int i = 0; i <= 20; i++)       // Loop to switch dice sides ramdomly
        {
            randomDiceSide = Random.Range(0, 6);            // Pick up random value from 0 to 5 (All inclusive)
            rend.sprite = diceSides[randomDiceSide];        // Set sprite to upper face of dice from array according to random value
            yield return new WaitForSeconds(0.05f);         // Pause before next itteration
        }

        finalSide = randomDiceSide + 1;
        controller.diceSideThrown = finalSide;          // Assigning final side



        if (controller.turn==1)
        {
            //Debug.Log("Inside Turn 1");
            
            controller.MovePlayer1();
            if (controller.p1didNotMove==false)
            {
                playerMove.Play();
                changeAttributesOf1.updateAttributes();
            }
            controller.turn=2;
            //Debug.Log("Turn changed after updating");
        }

        else if (controller.turn==2)
        {
            //Debug.Log("Inside turn 2");
            
            controller.MovePlayer2();
            if (controller.p2didNotMove==false)
            {
                playerMove.Play();
                changeAttributesOf2.updateAttributes();
            }
            controller.turn=1;
            //Debug.Log("Turn changed after updating");
        }
    }
}
