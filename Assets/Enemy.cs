using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	if(facingRight)
	{
		transform.Translate(Vector3.right * Time.fixedDeltaTime);
	}
	else
	{
		transform.Translate(Vector3.left * Time.fixedDeltaTime);
	}

    }
	    
}
