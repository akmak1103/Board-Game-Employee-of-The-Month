using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int diceSideThrown;
    public FollowThePath1 movePlayer1;
    public FollowThePath2 movePlayer2;
    public Player1Attributes p1;
    public Player2Attributes p2;
    bool qualification1;
    bool qualification2;
    public int turn;
    public bool isStartingP1,isStartingP2;

    public GameObject win1,win2,replay;

    public bool p1didNotMove,p2didNotMove;
    // Start is called before the first frame update
    void Start()
    {
        diceSideThrown = 0;
        turn = 1;
        qualification1=false;
        qualification2=false;
        isStartingP1 = true;
        isStartingP2 = true;
        p1didNotMove = false;
        p2didNotMove = false;
    }

    void qualify1()
    {
        if (p1.enthusiasm>=10 && p1.network>=10 && p1.capital>=10)
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
        if (movePlayer1.waypointIndex == 0 && isStartingP1 == true)
        {
            if (diceSideThrown==6 || diceSideThrown==1 )
            {
                isStartingP1 = false;
                movePlayer1.waypointIndex += diceSideThrown;
                p1didNotMove = false;
            }

            else
            {
                p1didNotMove = true;
                movePlayer1.waypointIndex = 0;
            }
        }

        else if ((36-movePlayer1.waypointIndex)>=diceSideThrown)
        {
            Debug.Log("Keep on moving till 36");
            movePlayer1.waypointIndex += diceSideThrown;
            p1didNotMove = false;
        }

        /*else if (movePlayer1.waypointIndex>=1 && movePlayer1.waypointIndex<=30)
        {
            Debug.Log("Till 30");
            movePlayer1.waypointIndex += diceSideThrown;
        }*/

        if (qualification1==true)
        {
            if (turn==1)
            {   
            if ((41-movePlayer1.waypointIndex)>=diceSideThrown)
            {
                Debug.Log("After 36");
                movePlayer1.waypointIndex += diceSideThrown;
            }
            }
        }


        if (movePlayer1.waypointIndex==36)
        {
            p1didNotMove = false;
            Debug.Log("On 36");
            qualify1();
            if (qualification1==false)
            {
                Debug.Log("Not qualified");
                movePlayer1.waypointIndex = 0;
            }
            else
            {
                Debug.Log("qualified and changed turn");
                turn=2;
            }
        }        

        if (movePlayer1.waypointIndex==41)
        {
            win1.SetActive(true);
            replay.SetActive(true);
            turn=0;
        }
    }

    public void MovePlayer2 ()
    {
        if (movePlayer2.waypointIndex == 0 && isStartingP2 == true)
        {
            if (diceSideThrown==6 || diceSideThrown==1 )
            {
                isStartingP2 = false;
                movePlayer2.waypointIndex += diceSideThrown;
                p2didNotMove = false;
            }

            else
            {
                p2didNotMove = true;
                movePlayer2.waypointIndex = 0;
            }
        }

        else if ((36-movePlayer2.waypointIndex)>=diceSideThrown)
        {
            Debug.Log("Keep on moving till 36");
            movePlayer2.waypointIndex += diceSideThrown;
            p2didNotMove = false;
        }


        if ((36-movePlayer2.waypointIndex)<diceSideThrown)
        {
            p2didNotMove=true;
        }

        /*else if (movePlayer1.waypointIndex>=1 && movePlayer1.waypointIndex<=30)
        {
            Debug.Log("Till 30");
            movePlayer1.waypointIndex += diceSideThrown;
        }*/

        if (qualification2==true)
        {
            if (turn==2)
            {   
            if ((41-movePlayer2.waypointIndex)>=diceSideThrown)
            {
                Debug.Log("After 36");
                movePlayer2.waypointIndex += diceSideThrown;
            }
            }
        }


        if (movePlayer2.waypointIndex==36)
        {
            p2didNotMove = false;
            Debug.Log("On 36");
            qualify2();
            if (qualification2==false)
            {
                Debug.Log("not qualified");
                movePlayer2.waypointIndex = 0;
            }
            else
            {
                turn=1;
                Debug.Log("qualified and turn changed");
            }
        }        

        if (movePlayer2.waypointIndex==41)
        {
            win2.SetActive(true);
            replay.SetActive(true);
            turn=0;
        }
    }
}
