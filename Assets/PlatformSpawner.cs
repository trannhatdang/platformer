using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
	[SerializeField] int platformCount = 10;
	[SerializeField] bool facingRight = true;
	[SerializeField] GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
	    StartCoroutine(routine());
    }
    // Update is called once per frame
    IEnumerator routine()
    {
	    for(int i = 0; i < platformCount; ++i)
	    {
		    for(int j = 0; j < 200; ++j)
		    {
			    yield return null;
		    }

		    Instantiate(platform, transform.position, transform.rotation).GetComponent<Platforms>().setFacingRight(facingRight);
	    }

	    Destroy(this.gameObject);
    }
    public void setFacingRight(bool value)
    {
	    facingRight = value;
    }
    public void setPlatformCount(int value)
    {
	    platformCount = value;
    }
}
