using UnityEngine;
using System.Collections;

public class AirEnemyMovement : MonoBehaviour {

	float attackSpeed = 10;
	float speed = 5;
	float wanderSpeed = 3;

    float amplitude = 1;

	GameObject player;
	GameObject[] groundObjs;

	Vector3 startPos;
	Vector3 leftPos;
	Vector3 rightPos;

	bool wandering;
	bool wanderRight;
	bool attacking;

	float attackDist = 5.0f;

    GameObject lazerEffect;
    GameObject laserBeamClone;
    bool isCoolingLazer;

	// Use this for initialization
	void Start () {
        lazerEffect = Resources.Load("Prefabs/Enemy/EnemyLazerBeam") as GameObject;
		player = GameObject.FindGameObjectWithTag ("Player");
		groundObjs = GameObject.FindGameObjectsWithTag ("Ground");
		wandering = true;
		wanderRight = true;
		startPos = transform.position;
		leftPos = Vector3.left * 5;
		leftPos += startPos;
		rightPos = Vector3.right * 5;
		rightPos += startPos;
		attacking = false;
        isCoolingLazer = false;
	}

	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, amplitude/100 * Mathf.Sin(wanderSpeed * Time.time) + transform.position.y, transform.position.z);

        //paused game
        if (GameObject.Find("GameManager").GetComponent<GameManager>().GetCurrGameState() != GAME_STATE.START_MENU && GameObject.Find("GameManager").GetComponent<GameManager>().GetCurrGameState() != GAME_STATE.PAUSED && !GameObject.Find("UIManager").GetComponent<UIManager>().GetPaused())
        {
            if ((transform.position - player.transform.position).magnitude < 15.0f)
            {
                wandering = false;
            }
            else
            {
                wandering = true;
            }

            if (wandering)
            {
                if (wanderRight)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    transform.Translate(-wanderSpeed * Time.deltaTime, 0, 0);
                    if ((transform.position - rightPos).magnitude < 1.0f)
                    {
                        SwitchWander();
                    }
                }
                else
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    transform.Translate(-wanderSpeed * Time.deltaTime, 0, 0);
                    if ((transform.position - leftPos).magnitude < 1.0f)
                    {
                        SwitchWander();
                    }
                }
            }
            else
            {
                if (attacking == false)
                {
                    if (transform.position.x > player.transform.position.x && (transform.position.x - player.transform.position.x) > attackDist)
                    {
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        transform.Translate(speed * Time.deltaTime, 0, 0);
                    }
                    else
                    {
                        attacking = true;
                    }

                    if (transform.position.x < player.transform.position.x && (transform.position.x + attackDist) < player.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                        transform.Translate(speed * Time.deltaTime, 0, 0);
                    }
                    else
                    {
                        attacking = true;
                    }
                }
                else
                {

                    if (transform.FindChild("airEnemy2Real") != null)
                    {
                        transform.FindChild("airEnemy2Real").localRotation = Quaternion.Euler(0, -90, 0);
                        transform.LookAt(player.transform.position);
                        Vector3 moveTowardDir = (player.transform.position - transform.position).normalized;
                        transform.Translate(moveTowardDir * 3.0f);
                    }
                    if (transform.FindChild("airEnemy1") != null)
                    {
                        if (player.transform.position.x > transform.position.x)
                        {
                            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                        }
                        else
                        {
                            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                        }
                        if (!isCoolingLazer)
                        {
                            // Vector3 laserDir = (player.transform.position - transform.FindChild("LazerFireLoc").transform.position);

                            isCoolingLazer = true;
                            Invoke("shootLazer", 1);
                            Invoke("resetCoolingLazer", 5);
                        }
                        if (GetComponent<LineRenderer>() != null)
                        {
                            GetComponent<LineRenderer>().SetPosition(0, transform.FindChild("LazerFireLoc").transform.position);
                            GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
                        }
                    }
                }
            }

            for (int i = 0; i < groundObjs.Length; i++)
            {
                GameObject currGround = groundObjs[i];

                if (transform.position.y > currGround.transform.position.y)
                {
                    if ((transform.position - currGround.transform.position).magnitude < 5.0f)
                    {
                        transform.Translate(0, wanderSpeed * Time.deltaTime, 0);
                    }
                }
            }

            //zero out the z
            Vector3 tempPos = new Vector3(this.transform.position.x, this.transform.position.y, startPos.z);
            this.transform.position = tempPos;
        }
	}

	void SwitchWander(){
		wanderRight = !wanderRight;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			Destroy (this.gameObject);
		}
	}

	public void SpeedChange(float num){
		wanderSpeed *= num;
		attackSpeed *= num;
		speed *= num;
	}

    public void shootLazer()
    {
        LineRenderer lr = gameObject.AddComponent<LineRenderer>();
        lr.SetVertexCount(2);
        lr.SetColors(Color.red, Color.yellow);
        lr.SetPosition(0, transform.FindChild("LazerFireLoc").transform.position);
        lr.SetPosition(1, player.transform.position);
        lr.SetWidth(0.3f, 0.5f);
        InvokeRepeating("addDamage", 0.1f, 0.1f);
        Invoke("destroyLazer", 0.8f);
    }

	public void ResetNormal(){
		speed = 5f;
		wanderSpeed = 3f;
		attackSpeed = 10f;
	}

    public void resetCoolingLazer()
    {
        isCoolingLazer = false;
    }
    
    public void destroyLazer()
    {
        CancelInvoke("addDamage");
        Destroy(GetComponent<LineRenderer>());
    }

    public void addDamage()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(1);
    }
}
