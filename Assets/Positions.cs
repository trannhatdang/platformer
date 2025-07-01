using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour
{
	[SerializeField] GameObject LowLeft;
	[SerializeField] GameObject LowRight;
	[SerializeField] GameObject MidLeft;
	[SerializeField] GameObject MidRight;
	
	public static Positions instance;

	void Awake()
	{
		if(instance && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
	}

	public GameObject getLowLeft()
	{
		return LowLeft;
	}

	public GameObject getLowRight()
	{
		return LowRight;
	}

	public GameObject getMidLeft()
	{
		return MidLeft;
	}

	public GameObject getMidRight()
	{
		return MidRight;
	}
}
