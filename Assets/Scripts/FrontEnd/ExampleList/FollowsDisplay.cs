using UnityEngine;
using System.Collections;

public class FollowsDisplay : MonoBehaviour
{

	public GameObject follows, notFollows;

	public void SetFollows(bool value)
	{
		follows.SetActive(value);
		notFollows.SetActive(!value);
	}

	public void Clear()
	{
		follows.SetActive(false);
		notFollows.SetActive(false);
	}

}

