using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class DeadScreen : ScreenBase {
	
	Button _restart;
	Button _quit;
	
	bool _hidden = false;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start ();
		_restart = GameObject.Find ("Restart").GetComponent<Button>();
		_quit = GameObject.Find ("Quit").GetComponent<Button>();
		
		_restart.interactable = true;
		_quit.interactable = true;
		
		_restart.onClick.AddListener (delegate () {
			_ui.DoFlowEvent(GAME_SCREEN.LOADING); 
			_game.DoFlowEvent(GAME_STATE.RESTART_LEVEL);});
		_quit.onClick.AddListener (delegate () {
			_ui.DoFlowEvent(GAME_SCREEN.QUIT);
			_game.DoFlowEvent(GAME_STATE.END);
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