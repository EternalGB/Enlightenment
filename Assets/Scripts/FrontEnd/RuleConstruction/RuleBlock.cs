using UnityEngine;
using System.Collections;
using System;

public abstract class RuleBlock : MonoBehaviour
{

	public Sprite previewSprite;
	public abstract INode GetNode();



}

