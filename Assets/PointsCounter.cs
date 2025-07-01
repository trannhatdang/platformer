using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

	    text.text = "Points: " + GameManager.instance.GetPoint().ToString();

        
    }
}
