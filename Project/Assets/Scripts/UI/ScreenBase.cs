using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScreenBase : MonoBehaviour {
	
	protected bool _open;
	protected bool _closed;
	protected UIManager _ui;
	protected GameManager _game;
	// Use this for initialization
	public virtual void Start() {
		_ui = (UIManager) GameObject.Find("UIManager").GetComponent("UIManager");
		_game = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");
		_closed = false;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}
	
	public virtual void OpenScreen()
	{
		//do open animations
		//on complete
		_open = true;
	}
	
	public virtual void CloseScreen()
	{
		_open = false;
		//do close animations
		//on complete
		_closed = true;
	}
	
	public bool isOpen()
	{
		return _open;
	}
	
	public bool isClosed()
	{
		return _closed;
	}
}
