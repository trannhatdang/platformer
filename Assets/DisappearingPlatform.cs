using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : Platforms
{
	public override void Start()
	{
	    rightLimit = GameManager.instance.getRightLimits();
	    StartCoroutine(routine());
	    Instantiate(apple, transform.position, Quaternion.identity, this.transform).transform.position += new Vector3(-.2f, .5f, 0);
	}

	IEnumerator routine()
	{
		SpriteRenderer[] sprs = GetComponentsInChildren<SpriteRenderer>();
		CompositeCollider2D coll = GetComponent<CompositeCollider2D>();
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		Color col = GetComponentInChildren<SpriteRenderer>().color;
		Color blurry = col, hidden = col;
		blurry.a = 0.7f; hidden.a = 0;
		while(true)
		{
			for(int i = 0; i < 30; ++i)
			{
				yield return null;
			}

			foreach(SpriteRenderer spr in sprs)
			{
				spr.color = blurry;
			}

			for(int i = 0; i < 30; ++i)
			{
				yield return null;
			}
			
			foreach(SpriteRenderer spr in sprs)
			{
				spr.color = hidden;
			}
			coll.isTrigger = true;
			rb.simulated = false;

			for(int i = 0; i < 30; ++i)
			{
				yield return null;
			}

			foreach(SpriteRenderer spr in sprs)
			{
				spr.color = col;
			}
			coll.isTrigger = false;
			rb.simulated = true;
		}

	}
}
