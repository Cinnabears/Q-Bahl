using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class LoadingScreen : ScreenBase {
	
	Button _continue;
	
	bool _hidden = false;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start ();
		_continue = GameObject.Find ("Continue").GetComponent<Button>();
		
		_continue.interactable = true;
		
		_continue.onClick.AddListener (delegate () {
			_ui.DoFlowEvent(GAME_SCREEN.NONE); 
			_game.DoFlowEvent(GAME_STATE.IN_GAME);});
	}
	
	void Hide(GameObject g)
	{
		g.GetComponent<CanvasGroup>().alpha = 0;
		g.GetComponent<CanvasGroup>().interactable = false;
		
	}
	
	void Show(GameObject g)
	{
		g.GetComponent<CanvasGroup>().alpha = 1;
		g.GetComponent<CanvasGroup>().interactable = true;
		
	}
	
	public override void OpenScreen()
	{
		//do open animations
		//on complete
		_open = true;
	}
	
	public override void CloseScreen()
	{
		_open = false;
		//do close animations
		//on complete
		_closed = true;
	}
}