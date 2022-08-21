using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreAnimation : MonoBehaviour
{
   public void AnimationScore()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }

    
    
}
