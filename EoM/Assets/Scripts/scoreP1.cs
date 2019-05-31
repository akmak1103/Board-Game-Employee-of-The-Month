using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreP1 : MonoBehaviour
{
    public Player1Attributes p1;
    Text score1;
    // Start is called before the first frame update
    void Start()
    {
        score1 = GetComponent<Text>();
        //score1.text = ("Player 1 score = \n" + p1.enthusiasm +"\n" + p1.network + "\n" + p1.capital);
    }

    // Update is called once per frame
    void Update()
    {
        score1.text = ("Player 1 score:\n\nEnthusiasm:" + p1.enthusiasm +"\nNetwork:" + p1.network + "\nCapital:" + p1.capital);
    }
}
