using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int diceSideThrown;
    public FollowThePath movePlayer1;
    public FollowThePath movePlayer2;
    public Player1Attributes p1;
    public Player2Attributes p2;
    bool qualification1;
    bool qualification2;
    public int turn;
    // Start is called before the first frame update
    void Start()
    {
        diceSideThrown = 0;
        turn = 1;
        qualification1=false;
        qualification2=false;
    }

    void qualify1()
    {
        if (p1.enthusiasm>=250 && p1.network>=300 && p1.capital>=200)
        qualification1 = true;
    }

    void qualify2()
    {
        if (p2.enthusiasm>=250 && p2.network>=300 && p2.capital>=200)
        qualification2 = true;
    }

    // Update is called once per frame
    public void MovePlayer1()
    {
        if (movePlayer1.waypointIndex == 0)
        {
            if (diceSideThrown==6 || diceSideThrown==1 )
            {
                movePlayer1.waypointIndex += diceSideThrown;
            }

            else
            {
                movePlayer1.waypointIndex = 0;
            }
        }

        else if (movePlayer1.waypointIndex>=1 && movePlayer1.waypointIndex<=30)
        {
            movePlayer1.waypointIndex += diceSideThrown;
        }

        else if ((36-movePlayer1.waypointIndex)>=diceSideThrown)
        {
            movePlayer1.waypointIndex += diceSideThrown;
        }

        else if (movePlayer1.waypointIndex==36)
        {
            qualify1();
            if (qualification1==true && (41-movePlayer1.waypointIndex)>=diceSideThrown)
            {
                movePlayer1.waypointIndex += diceSideThrown;
            }
            else
            {
                movePlayer1.waypointIndex = diceSideThrown;
            }
        }

        else if ((41-movePlayer1.waypointIndex)>=diceSideThrown)
        {
            movePlayer1.waypointIndex += diceSideThrown;
        }
        

        if (movePlayer1.waypointIndex==41)
        {
            turn=0;
        }
    }

    public void MovePlayer2 ()
    {
        if (movePlayer2.waypointIndex == 0)
        {
            if (diceSideThrown==6 || diceSideThrown==1 )
            {
                movePlayer2.waypointIndex += diceSideThrown;
            }

            else
            {
                movePlayer2.waypointIndex = 0;
            }
        }

        else if (movePlayer2.waypointIndex>=1 && movePlayer2.waypointIndex<=30)
        {
            movePlayer2.waypointIndex += diceSideThrown;
        }

        else if ((36-movePlayer2.waypointIndex)>=diceSideThrown)
        {
            movePlayer2.waypointIndex += diceSideThrown;
        }

        else if (movePlayer2.waypointIndex==36)
        {
            qualify2();
            if (qualification2==true && (41-movePlayer2.waypointIndex)>=diceSideThrown)
            {
                movePlayer2.waypointIndex += diceSideThrown;
            }
            else
            {
                movePlayer2.waypointIndex = diceSideThrown;
            }
        }

        else if ((41-movePlayer1.waypointIndex)>=diceSideThrown)
        {
            movePlayer1.waypointIndex += diceSideThrown;
        }

        
        if (movePlayer1.waypointIndex==41)
        {
            turn=0;
        }
    }
}
