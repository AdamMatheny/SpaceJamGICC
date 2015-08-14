using UnityEngine;
using Assets._Scripts.Managers;

namespace Assets._Scripts.Player
{
    public class PlayerControl : MonoBehaviour
    {
		public GameObject finishMarker;

		public GameObject[] players = new GameObject[0];
		public GameObject otherPlayer;

        [Header("Control Info")]
        [SerializeField]
        private float AxisDeadZone;
        [SerializeField]
        public string HorizontalAxisName; //Set up in Project Settings > Input
        [SerializeField]
        public string VerticalAxisName; //Set up in Project Settings > Input
        [SerializeField]
        private KeyCode FireButton;
        [SerializeField]
        private KeyCode SuperWeaponButton; //One button for all weapons or different buttons for different weapons, to decide later.

        [Header("Movement Variables")]
        [SerializeField]
<<<<<<< HEAD
        public float FlySpeed;
=======
        private float FlySpeed;
		private float mSpeedMod = 100;
		private float mSpeedReductionTimer = 3f;
		private bool mSlowed = false;

>>>>>>> origin/master
		public Rigidbody2D rgbd2D;

		void Start()
		{

			players = GameObject.FindGameObjectsWithTag ("Player");
			rgbd2D = GetComponent<Rigidbody2D> ();

			foreach(GameObject player in players){
				
				if(player != gameObject){
					
					otherPlayer = player;
				}
			}
		}

        void Update()
        {
			if(mSlowed)
			{
				mSpeedReductionTimer -= Time.deltaTime;
				if(mSpeedReductionTimer <= 0f)
				{
					mSlowed = false;
					mSpeedMod = 100;
					mSpeedReductionTimer = 3f;
				}
			}


			/*if(Input.GetKeyDown (SuperWeaponButton)){

				foreach(GameObject player in players){

					if(player != gameObject){

						Destroy(player);
					}
				}
			}*/ //Players test

            if (Input.GetAxis (HorizontalAxisName) >= AxisDeadZone || Input.GetAxis (HorizontalAxisName) <= -AxisDeadZone) {
				//gameObject.transform.Translate(Input.GetAxis(HorizontalAxisName) * FlySpeed * Time.deltaTime, 0, 0);
				rgbd2D.velocity = new Vector2 (Input.GetAxis (HorizontalAxisName) * FlySpeed * mSpeedMod * Time.deltaTime, rgbd2D.velocity.y);
			} else {

				rgbd2D.velocity = new Vector2 (0, rgbd2D.velocity.y);
			}

            if (Input.GetAxis (VerticalAxisName) >= AxisDeadZone || Input.GetAxis (VerticalAxisName) <= -AxisDeadZone) {
				//gameObject.transform.Translate(0,Input.GetAxis(VerticalAxisName) * FlySpeed * Time.deltaTime, 0);
				rgbd2D.velocity = new Vector2 (rgbd2D.velocity.x, Input.GetAxis (VerticalAxisName) * FlySpeed * mSpeedMod * Time.deltaTime);
			} else {

				rgbd2D.velocity = new Vector2 (rgbd2D.velocity.x, 0);
			}

			if (Input.GetKeyDown (SuperWeaponButton) && (gameObject.GetComponent<PlayerBase> ().PlayerWeaponsComponent.SuperWeapon1 != null)) {

				if(HorizontalAxisName == "Horizontal2") //Player 2
				{

<<<<<<< HEAD
					gameObject.GetComponent<PlayerBase>().PlayerWeaponsComponent.ShootSuperWeapon1(otherPlayer);
				}else{
=======
					gameObject.GetComponent<PlayerBase>().PlayerWeaponsComponent.ShootSuperWeapon1(true);
				}
				else
				{
>>>>>>> origin/master

					gameObject.GetComponent<PlayerBase>().PlayerWeaponsComponent.ShootSuperWeapon1(otherPlayer);
				}
				gameObject.GetComponent<PlayerBase> ().PlayerWeaponsComponent.SuperWeapon1 = null;
			}
        }

        public void SetUpPlayer1Controls()
        {
            HorizontalAxisName = ControlsManager.instance.Player1Controls.HorizontalAxis;
            VerticalAxisName = ControlsManager.instance.Player1Controls.VerticalAxis;
            FireButton = ControlsManager.instance.Player1Controls.BasicFireButton;
            SuperWeaponButton = ControlsManager.instance.Player1Controls.MegaWeaponFireButton;
        }

        public void SetUpPlayer2Controls()
        {
            HorizontalAxisName = ControlsManager.instance.Player2Controls.HorizontalAxis;
            VerticalAxisName = ControlsManager.instance.Player2Controls.VerticalAxis;
            FireButton = ControlsManager.instance.Player2Controls.BasicFireButton;
            SuperWeaponButton = ControlsManager.instance.Player2Controls.MegaWeaponFireButton;
        }

		//For reducing speed when hit ~Adam
		public void ReduceSpeed()
		{
			mSpeedMod = 50f;
			mSlowed = true;
			mSpeedReductionTimer = 3f;
		}
    }
}
