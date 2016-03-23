using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class CreditsScreen : ScreenBase {
	
	Button _startScreen;
	
	bool _hidden = false;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start ();
		_startScreen = GameObject.Find ("StartScreen").GetComponent<Button>();
		
		_startScreen.interactable = true;
		
		_startScreen.onClick.AddListener (delegate () {
			_ui.DoFlowEvent(GAME_SCREEN.SPLASH_SCREEN); 
			_game.DoFlowEvent(GAME_STATE.START_MENU);
			});
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