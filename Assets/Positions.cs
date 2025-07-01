using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour
{
	[SerializeField] GameObject LowLeft;
	[SerializeField] GameObject LowLeftPlat;
	[SerializeField] GameObject LowRight;
	[SerializeField] GameObject LowRightPlat;
	[SerializeField] GameObject MidLeft;
	[SerializeField] GameObject MidLeftPlat;
	[SerializeField] GameObject MidRight;
	[SerializeField] GameObject MidRightPlat;
	[SerializeField] GameObject HighLeft;
	[SerializeField] GameObject HighRight;
	
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
		DontDestroyOnLoad(this.gameObject);
	}

	public GameObject getLowLeft()
	{
		return LowLeft;
	}

	public GameObject getLowLeftPlat()
	{
		return LowLeftPlat;
	}

	public GameObject getLowRight()
	{
		return LowRight;
	}

	public GameObject getLowRightPlat()
	{
		return LowRightPlat;
	}

	public GameObject getMidLeft()
	{
		return MidLeft;
	}

	public GameObject getMidLeftPlat()
	{
		return MidLeftPlat;
	}

	public GameObject getMidRight()
	{
		return MidRight;
	}

	public GameObject getMidRightPlat()
	{
		return MidRightPlat;
	}

	public GameObject getHighLeft()
	{
		return HighLeft;
	}

	public GameObject getHighRight()
	{
		return HighRight;
	}
}
