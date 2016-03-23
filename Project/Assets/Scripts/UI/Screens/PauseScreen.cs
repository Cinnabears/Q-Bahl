using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public class PauseScreen : ScreenBase {
	
	Button _resumeGame;
	Button _stats;
	Button _options;
	Button _quit;
	
	bool _hidden = false;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start ();
		_resumeGame = GameObject.Find ("Resume").GetComponent<Button>();
		_stats = GameObject.Find ("Stats").GetComponent<Button>();
		_options = GameObject.Find ("Options").GetComponent<Button>();
		_quit = GameObject.Find ("Quit_Pause").GetComponent<Button> ();
		
		_resumeGame.interactable = true;
		_stats.interactable = true;
		_options.interactable = true;
		_quit.interactable = true;
		
		_resumeGame.onClick.AddListener (delegate () {
			_ui.resetPausedCounter();
			_ui.DoFlowEvent(GAME_SCREEN.NONE); 
			_game.DoFlowEvent(GAME_STATE.IN_GAME);
			CloseScreen();});
		_stats.onClick.AddListener (delegate() {
			_ui.DoFlowEvent(GAME_SCREEN.STATS);
			_game.DoFlowEvent(GAME_STATE.PAUSED);
		});
		_options.onClick.AddListener (delegate () {
			_ui.DoFlowEvent(GAME_SCREEN.OPTIONS);
			_game.DoFlowEvent(GAME_STATE.PAUSED);
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