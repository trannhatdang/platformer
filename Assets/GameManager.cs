using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	[SerializeField] Positions positions;
	[SerializeField] GameObject platform;
	[SerializeField] GameObject disappearingplatform;
	[SerializeField] GameObject spike;
	[SerializeField] int points;
	[SerializeField] GameObject YouLosePanel;
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
    // Start is called before the first frame update
    void Start()
    {
	    StartCoroutine(SpikeRoutine());
	    StartCoroutine(lowerPlatformRoutine());
	    StartCoroutine(midPlatformRoutine());
	    StartCoroutine(replacePlatforms());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpikeRoutine()
    {
	    while(true)
	    {
		    int SpikeCount = Random.Range(1, 10);

		    int pos = Random.Range(0, 6);

		    switch(pos)
		    {
				case 0:
				{
				    GameObject gb = Instantiate(spike, positions.getLowLeft().transform.position, Quaternion.identity);
				    gb.GetComponent<SpikesSpawner>().setSpikeCount(SpikeCount);
				    gb.GetComponent<SpikesSpawner>().setFacingRight(true);
				    break;
				}
				case 1:
				{
				    GameObject gb = Instantiate(spike, positions.getMidLeft().transform.position, Quaternion.identity);
				    gb.GetComponent<SpikesSpawner>().setSpikeCount(SpikeCount);
				    gb.GetComponent<SpikesSpawner>().setFacingRight(true);
				    break;
				}
				case 2:
				{
				    GameObject gb = Instantiate(spike, positions.getLowRight().transform.position, Quaternion.identity);
				    gb.GetComponent<SpikesSpawner>().setSpikeCount(SpikeCount);
				    gb.GetComponent<SpikesSpawner>().setFacingRight(false);
				    break;
				}
				case 3:
				{
				    GameObject gb = Instantiate(spike, positions.getMidRight().transform.position, Quaternion.identity);
				    gb.GetComponent<SpikesSpawner>().setSpikeCount(SpikeCount);
				    gb.GetComponent<SpikesSpawner>().setFacingRight(false);
				    break;
				}
				case 4:
				{
				    GameObject gb = Instantiate(spike, positions.getHighLeft().transform.position, Quaternion.identity);
				    gb.GetComponent<SpikesSpawner>().setSpikeCount(SpikeCount);
				    gb.GetComponent<SpikesSpawner>().setFacingRight(false);
				    break;
				}
				case 5:
				{
				    GameObject gb = Instantiate(spike, positions.getHighRight().transform.position, Quaternion.identity);
				    gb.GetComponent<SpikesSpawner>().setSpikeCount(SpikeCount);
				    gb.GetComponent<SpikesSpawner>().setFacingRight(false);
				    break;
				}
				default: 
				    Debug.Log("error");
				    break;
		    }


		    for(int i = 0; i < 42*3; ++i)
		    {
			    yield return null;
		    }
	    }
    }

    IEnumerator replacePlatforms()
    {
	    while(true)
	    {
		    for(int i = 0; i < 42 * 3; ++i)
		    {
			    yield return null;
		    }


		    GameObject temp = platform;
		    platform = disappearingplatform;

		    for(int i = 0; i < 42 * 2; ++i)
		    {
			    yield return null;
		    }

		    platform = temp;
	    }
    }


    IEnumerator lowerPlatformRoutine()
    {
	    while(true)
	    {
		    for(int i = 0; i < 8; ++i)
		    {
			    yield return null;
		    }
		    Instantiate(platform, positions.getLowLeftPlat().transform.position, Quaternion.identity).GetComponent<PlatformSpawner>().setPlatformCount(1);
		    for(int i = 0; i < 42 * 3; ++i)
		    {
			    yield return null;
		    }
	    }
    }

    IEnumerator midPlatformRoutine()
    {
	    while(true)
	    {
		    Instantiate(platform, positions.getMidLeftPlat().transform.position, Quaternion.identity).GetComponent<PlatformSpawner>().setPlatformCount(1);
		    for(int i = 0; i < 42 * 3; ++i)
		    {
			    yield return null;
		    }
	    }
    }

    public float getRightLimits()
    {
	    return positions.getLowRight().transform.position.x;
    }

    public float getLeftLimits()
    {
	    return positions.getLowLeft().transform.position.x;
    }

    public void AddPoint()
    {
	    points++;
    }

    public int GetPoint()
    {
	    return points;
    }

    public void Die()
    {
	    YouLosePanel.SetActive(true);
	    Destroy(Player.instance.gameObject);
    }

    public void Restart()
    {
	    SceneManager.LoadSceneAsync(0);
	    points = 0;
	    YouLosePanel.SetActive(false);
    }
}
