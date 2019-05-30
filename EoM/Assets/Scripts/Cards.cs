using System.Collections;
using UnityEngine;

public class Cards : MonoBehaviour {

    // Array of dice sides sprites to load from Resources folder
    private Sprite[] cardSides;
    int randomCardSide;
    public int cardSideThrown=0;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;
    public int finalSide = 0;

	// Use this for initialization
	private void Start () {

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        cardSides = Resources.LoadAll<Sprite>("Cards/");
	}
	

    public void ShuffleCard()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially

        StartCoroutine("cardAnimation");
        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomCardSide + 1;
      
        // Show final dice value in Console
        Debug.Log("Card selected = "+finalSide);
    }

    private IEnumerator cardAnimation()
    {
        randomCardSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 7 (All inclusive)
            randomCardSide = Random.Range(0, 7);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = cardSides[randomCardSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);   
        }
    }
}