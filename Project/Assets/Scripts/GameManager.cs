using UnityEngine;
using System.Collections;

public enum GAME_STATE
{
	START_MENU,
	IN_GAME,
	RESTART_LEVEL,
	LOADING,
	PAUSED,
	DEAD,
	GAME_OVER,
	CREDITS,
	END
}

public class GameManager : MonoBehaviour {

	public GAME_STATE currGameState;
	Queue _flowQueue;


	// Use this for initialization
	void Start () {
		_flowQueue = new Queue ();
		currGameState = GAME_STATE.START_MENU;
		_flowQueue.Enqueue (GAME_STATE.START_MENU);
	}
	
	// Update is called once per frame
	void Update () {

		//Clear flow queue
		while (_flowQueue.Count > 0)
		{
			switch ((GAME_STATE) _flowQueue.Dequeue())
			{
			case GAME_STATE.START_MENU:
				currGameState = GAME_STATE.START_MENU;
				break;
			case GAME_STATE.IN_GAME:
				currGameState = GAME_STATE.IN_GAME;
				break;
			case GAME_STATE.PAUSED:
				currGameState = GAME_STATE.PAUSED;
				break;
			case GAME_STATE.DEAD:
				currGameState = GAME_STATE.DEAD;
				break;
			case GAME_STATE.GAME_OVER:
				currGameState = GAME_STATE.GAME_OVER;
				break;
			case GAME_STATE.LOADING:
				currGameState = GAME_STATE.LOADING;
				break;
			case GAME_STATE.RESTART_LEVEL:
				currGameState = GAME_STATE.RESTART_LEVEL;
				break;
			case GAME_STATE.CREDITS:
				currGameState = GAME_STATE.CREDITS;
				break;
			case GAME_STATE.END:
				currGameState = GAME_STATE.END;
				Application.Quit();
				break;
			default:
				break;
			}
		}
	
	}

	//changes game screen
	public void DoFlowEvent(GAME_STATE f)
	{
		_flowQueue.Enqueue(f);
	}
}
