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
    
    public void Direction(Vector2Int direction)
    {
        if(direction.y<0)
            animator.SetInteger("direction", (int)States.up);
        else if(direction.y > 0)
            animator.SetInteger("direction", (int)States.down);
        if(direction.x < 0)
            animator.SetInteger("direction", (int)States.right);
        else if (direction.x > 0)
            animator.SetInteger("direction", (int)States.left);
    }
    public void Coloring(int color)
    {
        animator.SetInteger("color", color);
    }
}
