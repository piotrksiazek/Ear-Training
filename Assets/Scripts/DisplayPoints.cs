using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPoints : MonoBehaviour
{
    [SerializeField] Text pointsText; 
    void Start()
    {
        
    }

    void Update()
    {
        pointsText.text = CommonData.Instance.Points.ToString();
    }
}
