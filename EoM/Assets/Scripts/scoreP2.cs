using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreP2 : MonoBehaviour
{
    public Player2Attributes p2;
    Text score2;
    // Start is called before the first frame update
    void Start()
    {
        score2 = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        score2.text = ("Player 2 score:\n\nEnthusiasm:" + p2.enthusiasm +"\nNetwork:" + p2.network + "\nCapital:" + p2.capital);
    }
}