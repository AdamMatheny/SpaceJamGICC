using UnityEngine;

namespace Assets._Scripts.Player
{
    public class PlayerControl : MonoBehaviour
    {
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

        void Update()
        {
            if (Input.GetAxis(HorizontalAxisName) >= AxisDeadZone || Input.GetAxis(HorizontalAxisName) <= -AxisDeadZone)
            {
                gameObject.transform.Translate(Input.GetAxis(HorizontalAxisName) * FlySpeed * Time.deltaTime, 0, 0);
            }

            if (Input.GetAxis(VerticalAxisName) >= AxisDeadZone || Input.GetAxis(VerticalAxisName) <= -AxisDeadZone)
            {
                gameObject.transform.Translate(0,Input.GetAxis(VerticalAxisName) * FlySpeed * Time.deltaTime, 0);
            }

            if (Input.GetKeyDown(FireButton))
            {
                gameObject.GetComponent<PlayerBase>().PlayerWeaponsComponent.ShootBaseWeapon();
            }
        }


    }
}
