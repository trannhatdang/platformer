using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
	[SerializeField] bool facingRight = true;
	[SerializeField] protected GameObject apple;
	protected float rightLimit = 0;


    // Start is called before the first frame update
    public virtual void Start()
    {
	    rightLimit = GameManager.instance.getRightLimits();
	    Instantiate(apple, transform.position, Quaternion.identity, this.transform).transform.position += new Vector3(-.2f, .5f, 0);
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

    public void setFacingRight(bool value)
    {
	    facingRight = value;
    }
}
