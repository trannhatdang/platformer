using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
	[SerializeField]	bool facingRight = true;
	float rightLimit = 0;

    // Start is called before the first frame update
    void Start()
    {
	    rightLimit = GameManager.instance.getRightLimits();
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

	if(Mathf.Abs(transform.position.x) > rightLimit)
	{
		Destroy(this.gameObject);
	}

    }

    public void setFacingRight(bool val)
    {
	    facingRight = val;
    }
}
