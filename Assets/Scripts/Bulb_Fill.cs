using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulb_Fill : MonoBehaviour
{
    public Image progress;
    private float ult = 100;
    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        progress.fillAmount = GameManager.instance.ultimateProgress / 100.0f; ;
    }
}
