using UnityEngine;
using System.Collections;
using Assets._Scripts.Managers;

namespace Assets._Scripts.Player
{
	public class PlayerControl : MonoBehaviour
	{
		
		public GameObject[] players = new GameObject[0]; // ~ For checking the other player
		public GameObject otherPlayer;
		
		[Header("Control Info")]
		[SerializeField]
		private float AxisDeadZone;
		[SerializeField]
		public string HorizontalAxisName; //Input Manager Shtuffs
		[SerializeField]
		public string VerticalAxisName; 
		[SerializeField]
		private KeyCode SuperWeaponButton; 
		
		[Header("Movement Variables")]
		[SerializeField]
		public float FlySpeed;
		public Rigidbody2D rgbd2D;
		public float mSpeedMod = 1.0f;
		public float mSpeedModTimer = 0f;

		void Start(){
			
			players = GameObject.FindGameObjectsWithTag ("Player"); //Might of got this wrong, will check later ~ Jonathan
			rgbd2D = GetComponent<Rigidbody2D> (); //Get the RigidBody
			
			foreach(GameObject player in players){
				
				if(player != gameObject){
					
					otherPlayer = player;
				}
			} //Go through the players and get the one that is not us.
		}
		
		void Update()
		{
			//Fix player's speed after a few seconds if slowed down ~Adam
			if(mSpeedMod != 1.0f)
			{
				mSpeedModTimer -= Time.deltaTime;

				if(mSpeedModTimer <= 0f)
				{
					mSpeedMod = 1.0f;
				}
			}

			//Move player around, does work with controllers (Kinda) Will get 100% later ~ Jonathan


			if (Input.GetAxis (HorizontalAxisName) >= AxisDeadZone || Input.GetAxis (HorizontalAxisName) <= -AxisDeadZone) {
				rgbd2D.velocity = new Vector2 (Input.GetAxis (HorizontalAxisName) * FlySpeed * mSpeedMod * Time.deltaTime, rgbd2D.velocity.y);
			} else {
				rgbd2D.velocity = new Vector2 (0, rgbd2D.velocity.y);
			}
			
			if (Input.GetAxis (VerticalAxisName) >= AxisDeadZone || Input.GetAxis (VerticalAxisName) <= -AxisDeadZone) {
				rgbd2D.velocity = new Vector2 (rgbd2D.velocity.x, Input.GetAxis (VerticalAxisName) * FlySpeed * mSpeedMod * Time.deltaTime);
			} else {
				rgbd2D.velocity = new Vector2 (rgbd2D.velocity.x, 0);
			}

			if (Input.GetKeyDown (SuperWeaponButton) && (gameObject.GetComponent<PlayerBase> ().PlayerWeaponsComponent.SuperWeapon1 != null)) {

				//I think I had some horizontal check thing here, screw that though ~ Jonathan

				gameObject.GetComponent<PlayerBase>().PlayerWeaponsComponent.ShootSuperWeapon1(otherPlayer);
				gameObject.GetComponent<PlayerBase> ().PlayerWeaponsComponent.SuperWeapon1 = null;
			}
		}

		public void InvertTimer(){

			StartCoroutine ("InvertTimerEnum");
		}

		private IEnumerator InvertTimerEnum()
		{
			while (true)
			{
				yield return new WaitForSeconds(6);
				FlySpeed *= -1;
			}
		}

        public void SetUpControlsAsPlayer1()
        {
            HorizontalAxisName = ControlsManager.instance.Player1Controls.HorizontalAxis;
            VerticalAxisName = ControlsManager.instance.Player1Controls.VerticalAxis;
            SuperWeaponButton = ControlsManager.instance.Player1Controls.MegaWeaponFireButton;
        }

        public void SetUpControlsAsPlayer2()
        {
            HorizontalAxisName = ControlsManager.instance.Player2Controls.HorizontalAxis;
            VerticalAxisName = ControlsManager.instance.Player2Controls.VerticalAxis;
            SuperWeaponButton = ControlsManager.instance.Player2Controls.MegaWeaponFireButton;
        }
	}
}
