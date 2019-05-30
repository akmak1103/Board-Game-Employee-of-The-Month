using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int diceSideThrown;
    public FollowThePath movePlayer;
    // Start is called before the first frame update
    void Start()
    {
        diceSideThrown = 0;
    }

    // Update is called once per frame
    public void MovePlayer()
    {
        /*int count=1;
        for (int i = 40; i>=36; i--)
        {
            if (movePlayer.waypointIndex == i)
            {
                if (diceSideThrown==count)
                {
                    movePlayer.waypointIndex += diceSideThrown;
                }
            }
            count+=1;
        }*/

        if (movePlayer.waypointIndex == 0)
        {
            if (diceSideThrown==6 || diceSideThrown==1 )
            {
                movePlayer.waypointIndex += diceSideThrown;
            }

            else
            {
                movePlayer.waypointIndex = 0;
            }
        }

        else if (movePlayer.waypointIndex>=1 && movePlayer.waypointIndex<=35)
        {
            movePlayer.waypointIndex += diceSideThrown;
        }

        else if ((41-movePlayer.waypointIndex)>=diceSideThrown)
        {
            movePlayer.waypointIndex += diceSideThrown;
        }
    }
}
