﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attributes : MonoBehaviour
{
    public int enthusiasm;
    public int capital;
    public int network;
    public FollowThePath1 position;
    public FollowThePath2 opponentPosition;
    public Cards blankPosition;
    public Player2Attributes opponent;
    public GameControl start;
    // Start is called before the first frame update
    void Start()
    {
        enthusiasm=100;
        capital=100;
        network=100;
    }
    private IEnumerator someDelay(){
        yield return new WaitForSeconds(1.5f);

        //Power of Attorney
        if (blankPosition.finalSide==1)
        {
            start.isStartingP2 = true;
            opponent.enthusiasm=100;
            opponent.network=100;
            opponent.capital=100;
            opponentPosition.waypointIndex=0;

        }
        //Meeting
        if (blankPosition.finalSide==2)
            {
                enthusiasm+=-20;
                capital+=0;
                network+=10;
                //Debug.Log("Card drawn = "+blankPosition.finalSide);
            }

        //Party
        if (blankPosition.finalSide==3)
        {
            enthusiasm+=30;
            capital+=-30;
            network+=0;
            //Debug.Log("Card drawn = "+blankPosition.finalSide);
        }

        //Rumour
        if (blankPosition.finalSide==4)
        {
            opponent.enthusiasm+=-20;
            opponent.capital+=0;
            opponent.network+=-20;
            //Debug.Log("Card drawn = "+blankPosition.finalSide);
        }


        //Leave
        if (blankPosition.finalSide==5)
        {
            enthusiasm+=20;
            capital+=0;
            network+=-20;
            //Debug.Log("Card drawn = "+blankPosition.finalSide);
        }

        //Bonus
        if (blankPosition.finalSide==6)
        {
            enthusiasm+=30;
            capital+=30;
            network+=0;
            //Debug.Log("Card drawn = "+blankPosition.finalSide);
        }

        //Break
        if (blankPosition.finalSide==7)
        {
            enthusiasm+=10;
            capital+=-20;
            network+=0;
            //Debug.Log("Card drawn = "+blankPosition.finalSide);
        }

        //Promotion
        if (blankPosition.finalSide==8)
        {
            enthusiasm+=20;
            capital+=0;
            network+=20;
            //Debug.Log("Card drawn = "+blankPosition.finalSide);
        }

    }

    // Update is called once per frame
    public void updateAttributes()
    {
        //Tuesdays
        if (position.waypointIndex==1 || position.waypointIndex==12 || position.waypointIndex==23 || position.waypointIndex==31)
        {
            enthusiasm+=-10;
            capital+=20;
            network+=0;
        }


        //Wednesdays
        else if (position.waypointIndex==2 || position.waypointIndex==14 || position.waypointIndex==25 || position.waypointIndex==35)
        {
            enthusiasm+=0;
            capital+=20;
            network+=20;
        }
        
        //Thursdays
        else if (position.waypointIndex==4 || position.waypointIndex==16 || position.waypointIndex==26 || position.waypointIndex==33)
        {
            enthusiasm+=0;
            capital+=10;
            network+=10;
        }

        //Fridays
        else if (position.waypointIndex==6 || position.waypointIndex==17 || position.waypointIndex==27)
        {
            enthusiasm+=20;
            capital+=0;
            network+=10;
        }

        //Saturdays
        else if (position.waypointIndex==8 || position.waypointIndex==18 || position.waypointIndex==28)
        {
            enthusiasm+=20;
            capital+=-30;
            network+=0;
        }

        //Sundays
        else if (position.waypointIndex==9 || position.waypointIndex==19 || position.waypointIndex==29)
        {
            enthusiasm+=0;
            capital+=30;
            network+=20;
        }

        //Mondays
        else if (position.waypointIndex==10 || position.waypointIndex==21 || position.waypointIndex==36)
        {
            enthusiasm+=-20;
            capital+=0;
            network+=-10;
        }

        //blankPosition
        else if (position.waypointIndex==3 || position.waypointIndex==5 || position.waypointIndex==7 || position.waypointIndex==11
        || position.waypointIndex==13 || position.waypointIndex==15 || position.waypointIndex==20 || position.waypointIndex==22 
        || position.waypointIndex==24 || position.waypointIndex==30 || position.waypointIndex==32 || position.waypointIndex==34)
        {
            blankPosition.ShuffleCard();
            StartCoroutine("someDelay");
            //Meeting
            
        }
    }
}
