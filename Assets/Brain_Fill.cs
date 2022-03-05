using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brain_Fill : MonoBehaviour
{
    public Image progress;
    private float health=100;
    private GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        
    }



        // Update is called once per frame
        void Update()
        {
        progress.fillAmount = GM.GetComponent<GameManager>().playerHealthLevel;
        }
   }

