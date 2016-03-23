using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class SplashScreen : ScreenBase {

	Button _playGame;
	Button _credits;
	Button _quit;
	
	bool _hidden = false;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start ();
		_playGame = GameObject.Find ("Play_Game").GetComponent<Button>();
		_credits = GameObject.Find ("Credits").GetComponent<Button>();
		_quit = GameObject.Find ("Quit").GetComponent<Button>();

		_playGame.interactable = true;
		_credits.interactable = true;
		_quit.interactable = true;

		_playGame.onClick.AddListener (delegate () {
			_ui.DoFlowEvent(GAME_SCREEN.NONE); 
			_game.DoFlowEvent(GAME_STATE.IN_GAME);});
		_credits.onClick.AddListener (delegate() {
			_ui.DoFlowEvent(GAME_SCREEN.CREDITS);
			_game.DoFlowEvent(GAME_STATE.CREDITS);
		});
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