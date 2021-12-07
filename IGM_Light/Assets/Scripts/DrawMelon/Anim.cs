using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animator animator;

    enum States
    {
        up = 1,
        down = 2,
        left = 3,
        right = 4,
        idle = 0
    }

    public void Directioning(int direction)
    {
        animator.SetInteger("direction", direction);
    }
    
    public int Direction(Vector2Int direction)
    {
        if(direction.y<0)
        {
            //Debug.Log("up");
            animator.SetInteger("direction", (int)States.up);
            return 1;
        }
           
        else if(direction.y > 0)
        {
            //Debug.Log("down");
            animator.SetInteger("direction", (int)States.down);
            return 2;
        }
            
        if(direction.x < 0)
        {
            animator.SetInteger("direction", (int)States.right);
            return 4;    
        }
        else if (direction.x > 0)
        {
            animator.SetInteger("direction", (int)States.left);
            return 3;
        }

        return 0;
    }
    public void Coloring(int color)
    {
        Debug.Log(color);
        animator.SetInteger("color", color);
    }

    public void Sliding()
    {
       // Debug.Log("sliding");
        animator.SetBool("sliding", true);
    }

    public void Moving()
    {
        //Debug.Log("moving");
        animator.SetBool("sliding", false);
    }
}
