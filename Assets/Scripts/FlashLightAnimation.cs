using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimatorEnd()
    {
        this.GetComponent<Animator>().enabled = false;
    }
}
