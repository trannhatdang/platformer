using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesSpawner : MonoBehaviour
{
	[SerializeField] int spikeCount = 10;
	[SerializeField] bool facingRight = true;
	[SerializeField] GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
	    StartCoroutine(routine());
    }
    // Update is called once per frame
    IEnumerator routine()
    {
	    for(int i = 0; i < spikeCount; ++i)
	    {
		    for(int j = 0; j < 42; ++j)
		    {
			    yield return null;
		    }

		    Instantiate(spike, transform.position, transform.rotation).GetComponent<Spikes>().setFacingRight(facingRight);
	    }
    }
    public void setFacingRight(bool value)
    {
	    facingRight = value;
    }
    public void setSpikeCount(int value)
    {
	    spikeCount = value;
    }
}
