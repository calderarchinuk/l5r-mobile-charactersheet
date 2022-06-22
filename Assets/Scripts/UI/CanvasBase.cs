using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBase : MonoBehaviour
{
	public virtual void Start()
	{
		GameInstance.OnGameStateChanged += GameInstance_OnGameStateChanged;
	}

	public virtual void GameInstance_OnGameStateChanged (GameState state)
	{
	}

	//enables/disables the canvas
	//should also close any popups
	public virtual void SetVisible(bool visible)
	{
		GetComponent<Canvas>().enabled = visible;
	}
}
