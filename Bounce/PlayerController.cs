using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public int totalDeaths = 0;
	bool onBlock = false;
	public Vector2 respawn;
	public bool isDead = false;
	public const int teleport = 2;
	public bool teleColliderCheck = false;
	float cooldownTele = 10;
	public Vector2 offset = new Vector2 (6, 6);
	public GameObject teleportObject;
	private Transform teleAni;

	public Vector2 startingGravity;
	public bool cantControl = false;
	public bool hitByBubble = false;
	float hitByBubbleTimer = 2f;
	public float hitByBubbleStart;
	public GameObject BubbleObject;

	public EventSystem eventSystem;
	private GameObject ActiveButton;
	private GameObject PauseButton;
	private GameObject JumpButton;
	private GameObject ResumeButton;
	float cooldownStart = -20;
	/*
	public const int bombActive = 0;
	//public GameObject bombCoco;
	//public GameObject bombTnt;
	float cooldownStart = -20;
	public float bombCooldown = 15;
	//public float bombTimeLeft;
	public bool plantedBomb = false;
	public GameObject bombObject;
*/

	public const int speedActive = 1;
	//public GameObject speed;
	public const float speedTime = .5f;
	public float speedCooldown = 15;
	public float speedTimeLeft;
	bool speedActivated = false;

	public const int shieldActive = 3;
	public GameObject shield;
	public bool shieldActivated = false;
	float shieldCooldown = 20;
	const float shieldActiveTime = 3;
    float currentShieldTime;

	public int currentActive = 0;
	public int currentPassive;

	const int fasterPassive = 0;
	const int immunePassive = 1;
	public bool immunePassiveActive = false;
	public float currentPassiveCooldown = -15;
	public float cooldownImmune = 15;

	const int slowPassive = 2;

	public const int paused = 1;
	public const int inGamePaused = 4;
	public const int running = 2;
	public const int end = 3;
	public int currentState;

	public bool facingRight = true;			// For determining which way the player is currently facing.
	public bool jump = false;				// Condition for whether the player should jump.
	float currentMaxSpeed;

	float moveForce = 5f;			// Amount of force added to move the player left and right.
	float maxSpeed = 4f;				// The fastest the player can travel in the x axis.
	float jumpForce = 300f;			// Amount of force added when the player jumps.
	
	bool grounded = false;			// Whether or not the player is grounded.

	public bool inCannon = false;
	bool inCannonAir = false;
	Vector2 CannonVel = new Vector2 (700f, 700f);
	float cannonMaxSpeed = 50f;

	bool onSpeedBlock = false;
	bool afterSpeedBlock = false;
	Vector2 speedBlock = new Vector2(400f, 0);
	const float speedMaxSpeed = 10f;
	float currentTimeForSpeed;
	float h;
	bool started = false;
	public GameObject deaths;
	public GameObject finishScreen1;
	public GameObject cooldownActive;

	public onStart starter;

	void Start(){
		GameObject playerS = GameObject.FindGameObjectWithTag("playerSpawn").gameObject;
		transform.position = playerS.transform.position;
		Instantiate(teleportObject, new Vector3(-10, -10, 0), Quaternion.identity);
		//PauseButton = GameObject.FindGameObjectWithTag ("pause").gameObject;
		teleportObject = GameObject.FindGameObjectWithTag("teleCollider").gameObject;
		teleAni = GameObject.FindGameObjectWithTag("teleAni").transform;
		currentMaxSpeed = maxSpeed;
		startingGravity = Physics2D.gravity;
	}

	void FixedUpdate ()
	{
		if (starter.start) {
			JumpButton = GameObject.FindGameObjectWithTag ("jump").gameObject;
			deaths = GameObject.FindGameObjectWithTag("deathCount").gameObject;
			cooldownActive = GameObject.FindGameObjectWithTag("cooldownTimer").gameObject;
			if (currentActive == teleport) {
				ActiveButton = GameObject.FindGameObjectWithTag ("teleportActive").gameObject;
				ActiveButton.GetComponent<Image> ().enabled = true;
			} else if (currentActive == shieldActive) {
				ActiveButton = GameObject.FindGameObjectWithTag ("shieldActive").gameObject;
				ActiveButton.GetComponent<Image> ().enabled = true;
			} else if (currentActive == speedActive) {
				ActiveButton = GameObject.FindGameObjectWithTag ("speedActive").gameObject;
				ActiveButton.GetComponent<Image> ().enabled = true;
			}

			if (currentPassive == fasterPassive && started == false) {
				maxSpeed *= 1.1f;
				moveForce *= 1.1f;
				started = true;
			}
		}
		else
			return;

			if (currentState == paused)
				return;

			checkImmunePassive ();
			checkShield ();
			checkTele ();
			checkIfDead ();
			bubbleHit ();
			checkSpeed ();
			cannonCheck ();
			checkPowers ();
			updateCooldowns ();
			updateMovement ();
	}
	/*
	void InGamePause(){
		if (eventSystem.currentSelectedGameObject == ResumeButton) {
			eventSystem.SetSelectedGameObject (null);
			ResumeButton.GetComponent<Image>().enabled = false;
			currentState = -1;
			Time.timeScale = 1;
		}
	}
	*/
	void OnCollisionEnter2D(Collision2D col) { 
		if (col.gameObject.tag == "speedBlock") {
			onSpeedBlock = true;
				}
		if (col.gameObject.tag == "Respawn") {
			respawn = new Vector2(transform.position.x, transform.position.y);
		}
		if (col.gameObject.tag == "rotatingBlock") {
			if(!jump)
				onBlock = true;
		}
		if (col.gameObject.tag == "deathBlock") {
			isDead = true;
		}
		if (col.gameObject.tag == "lava") {
			isDead = true;
		}
		if (col.gameObject.tag == "Finish") {
			cantControl = true;
			finishScreen1.GetComponent<Finish> ().finished = true;
			currentState = paused;
		}
	}
	/*
	void checkPause(){
		if (eventSystem.currentSelectedGameObject == PauseButton) {
			eventSystem.SetSelectedGameObject (null);
			ResumeButton.GetComponent<Image>().enabled = true;
			currentState = inGamePaused;
			Time.timeScale = 0;
			if(Time.timeScale == 0)
				Debug.Log ("Pause");
		}
	}
*/
	void checkImmunePassive(){
		if (currentPassive == immunePassive) {
			if(currentPassiveCooldown < Time.time){
				immunePassiveActive = true;
			}
		}
	}

	void updateCooldowns(){
		if (currentActive == speedActive) {
			if(cooldownStart + speedCooldown > Time.time)
				updateCooldownTimer(speedCooldown);

		} else if (currentActive == teleport) {
			if(cooldownStart + cooldownTele > Time.time)
				updateCooldownTimer(cooldownTele);
			
		} else if (currentActive == shieldActive) {
			if(cooldownStart > Time.time)
				updateCooldownTimer(0);	
		}
	}

	void updateCooldownTimer(float currentCooldown){
		float ms = 0f;
		float sec = 0f;

		string msS;
		string secS;


		ms = ((cooldownStart + currentCooldown) - Time.time)*60;
		Debug.Log (ms);
		
		sec = (int)ms/60;
		secS = sec.ToString();
		ms = (int)(ms - (sec*60));
		msS = ms.ToString();
		
		if (sec > 0)
			cooldownActive.GetComponent<Text> ().text = (secS + ":" + msS);
		else
			cooldownActive.GetComponent<Text> ().text = "ACTIVE";
	}
	
	void checkPowers(){

		if(Time.time < 3f)
			eventSystem.SetSelectedGameObject(null);

		if (eventSystem.currentSelectedGameObject == ActiveButton) {
			eventSystem.SetSelectedGameObject(null);
			
			if(currentActive == speedActive){
				if(cooldownStart + speedCooldown < Time.time){
					speedTimeLeft = Time.time;
					speedActivated = true;
				}
			}

			if(currentActive == teleport){
				if(cooldownStart + cooldownTele < Time.time){
					teleportObject.rigidbody2D.isKinematic = false;
					teleAni.renderer.enabled = true;
					teleportObject.GetComponent<teleport> ().collider2D.enabled = true;
					teleportObject.GetComponent<teleport> ().teleportActive = true;
					teleportObject.transform.position = new Vector2(rigidbody2D.position.x + offset.x, rigidbody2D.position.y + offset.y);
					teleportObject.GetComponent<teleport> ().renderer.enabled = true;
					cooldownStart = Time.time;
				}
				else
					updateCooldownTimer(cooldownTele);
			}

			/*
			if(currentActive == bombActive){
				if(cooldownStart < Time.time){
					plantedBomb = true;
					cooldownStart = Time.time + bombCooldown;
				}
			}
*/
			if(currentActive == shieldActive){
				if(cooldownStart < Time.time){
					shieldActivated = true;
					cooldownStart = shieldCooldown + Time.time;
					currentShieldTime = shieldActiveTime + Time.time;
					shield.renderer.enabled = true;
				}
			}
		}
	}

	void checkShield(){
		if ((shieldActivated == true) && (currentShieldTime < Time.time)) {
			shieldActivated = false;
			shield.renderer.enabled = false;
		}
	}

	void cannonCheck(){
		if (inCannon == true) {
			rigidbody2D.AddForce(CannonVel);
			inCannon = false;
			inCannonAir = true;
			grounded = false;
			currentMaxSpeed = cannonMaxSpeed;
			return;
		}
		
		if (inCannonAir) {
			if(rigidbody2D.velocity.y == 0){
				inCannonAir = false;
				currentMaxSpeed = maxSpeed;
			}
			return;
		}
	}

	void checkSpeed(){
		if (speedActivated) {
			if(speedTimeLeft + speedTime < Time.time){
				currentMaxSpeed = maxSpeed;
				speedActivated = false;
				cooldownStart = Time.time;
			}
			else
				speedSkill ();
		}
		
		if (end == currentState) {
			return;
		}
		if (onSpeedBlock == true) {
			currentMaxSpeed = speedMaxSpeed;
			rigidbody2D.velocity = speedBlock;
			currentTimeForSpeed = Time.deltaTime;
			onSpeedBlock = false;
		}
		
		if ((afterSpeedBlock == true) && (currentTimeForSpeed + 1 > Time.deltaTime)) {
			currentMaxSpeed = maxSpeed;
			afterSpeedBlock = false;
		}
	}

	void checkIfDead(){
		if (isDead == true) {
			rigidbody2D.velocity = new Vector2(0f, 0f);
			rigidbody2D.isKinematic = true;
			transform.position = respawn;
			rigidbody2D.isKinematic = false;
			isDead = false;
			cantControl = false;
			totalDeaths++;
			deaths.GetComponent<Text>().text = totalDeaths.ToString();
			}

		rigidbody2D.isKinematic = false;
	}

	void checkTele(){
		if (teleColliderCheck) {
			teleAni.renderer.enabled = false;
			transform.position = teleportObject.transform.position;
			teleportObject.transform.position = new Vector2(respawn.x, respawn.y + 5f);
			teleportObject.rigidbody2D.isKinematic = true;
			teleColliderCheck = false;
			teleportObject.GetComponent<teleport> ().teleportActive = false;
			teleportObject.GetComponent<teleport> ().renderer.enabled = false;
			}
	}

	void updateMovement(){
		Vector3 curAc;

		if (transform.position.y < -1)
			isDead = true;
		if (rigidbody2D.velocity.y == 0)
			grounded = true;
		else if (onBlock)
			grounded = true;
		
		// Cache the horizontal input.

		if (!cantControl) {
			if(SystemInfo.deviceType == DeviceType.Desktop)
			{
				h = Input.GetAxis ("Horizontal");
			}
			else{
				//curAc = Vector3.Lerp(curAc, Input.acceleration - zeroAc, Time.deltaTime/smooth);
				h = Input.acceleration.x;
			}
			}

			if ((Input.GetButton ("Jump") || eventSystem.currentSelectedGameObject == JumpButton) && grounded) {
					eventSystem.SetSelectedGameObject(null);
					jump = true;
					grounded = false;
					onBlock = false;
				}
			
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < currentMaxSpeed)
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > currentMaxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * currentMaxSpeed, rigidbody2D.velocity.y);
		
		if(jump)
		{
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}

	void speedSkill(){
		onSpeedBlock = true;
	}

	void bombSkill(){

	}

	void bubbleHit(){
		Vector2 newVelocity = new Vector2 (1f, 1f);
		if (hitByBubble) {
			//hitByBubbleStart = Time.time;
			if(hitByBubbleStart + hitByBubbleTimer < Time.time){
				hitByBubble = false;
				cantControl = false;
				Physics2D.gravity = startingGravity;
				BubbleObject.renderer.enabled = false;
			}
			else{
				rigidbody2D.velocity = newVelocity;
				cantControl = true;
				Physics2D.gravity = Vector2.zero;
				BubbleObject.renderer.enabled = true;
			}
		}
	}
}

