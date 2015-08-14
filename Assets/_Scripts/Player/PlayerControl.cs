using UnityEngine;

namespace Assets._Scripts.Player
{
    public class PlayerControl : MonoBehaviour
    {
		public GameObject finishMarker;

        [Header("Control Info")]
        [SerializeField]
        private float AxisDeadZone;
        [SerializeField]
        private string HorizontalAxisName; //Set up in Project Settings > Input
        [SerializeField]
        private string VerticalAxisName; //Set up in Project Settings > Input
        [SerializeField]
        private KeyCode FireButton;
        [SerializeField]
        private KeyCode SuperWeaponButton; //One button for all weapons or different buttons for different weapons, to decide later.

        [Header("Movement Variables")]
        [SerializeField]
        private float FlySpeed;
		public Rigidbody2D rgbd2D;

		void Start(){

			rgbd2D = GetComponent<Rigidbody2D> ();
		}

        void Update()
        {

            if (Input.GetAxis (HorizontalAxisName) >= AxisDeadZone || Input.GetAxis (HorizontalAxisName) <= -AxisDeadZone) {
				//gameObject.transform.Translate(Input.GetAxis(HorizontalAxisName) * FlySpeed * Time.deltaTime, 0, 0);
				rgbd2D.velocity = new Vector2 (Input.GetAxis (HorizontalAxisName) * FlySpeed * Time.deltaTime, rgbd2D.velocity.y);
			} else {

				rgbd2D.velocity = new Vector2 (0, rgbd2D.velocity.y);
			}

            if (Input.GetAxis (VerticalAxisName) >= AxisDeadZone || Input.GetAxis (VerticalAxisName) <= -AxisDeadZone) {
				//gameObject.transform.Translate(0,Input.GetAxis(VerticalAxisName) * FlySpeed * Time.deltaTime, 0);
				rgbd2D.velocity = new Vector2 (rgbd2D.velocity.x, Input.GetAxis (VerticalAxisName) * FlySpeed * Time.deltaTime);
			} else {

				rgbd2D.velocity = new Vector2 (rgbd2D.velocity.x, 0);
			}

			//No need for this since there will be auto fire ~ Jonathan
            /*if (Input.GetKeyDown(FireButton))
            {
                gameObject.GetComponent<PlayerBase>().PlayerWeaponsComponent.ShootBaseWeapon();
            }*/
        }
    }
}
