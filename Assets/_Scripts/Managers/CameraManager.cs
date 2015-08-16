using UnityEngine;
using System.Collections;

namespace Assets._Scripts.Managers
{
    public class CameraManager : Singleton<CameraManager>
    {
        public Camera Player1Camera;
        public Camera Player2Camera;

        protected override void Awake()
        {
            base.Awake();
            Application.targetFrameRate = 30;
        }

        public void SetVisualHindranceForPlayer(int playerIndex)
        {
            switch (playerIndex)
            {
                case 1:
                    StartCoroutine("SetHinderenceForPlayer1");
                    break;
                case 2:
                    StartCoroutine("SetHinderenceForPlayer2");
                    break;
            }
        }

		private IEnumerator SetHinderenceForPlayer1()
        {
            Player1Camera.GetComponent<CameraFilterPack_TV_Vcr>().enabled = true;
            Player1Camera.GetComponent<CameraFilterPack_TV_VHS>().enabled = true;
            yield return new WaitForSeconds(10.0f);
            Player1Camera.GetComponent<CameraFilterPack_TV_Vcr>().enabled = false;
            Player1Camera.GetComponent<CameraFilterPack_TV_VHS>().enabled = false;
        }

		private IEnumerator SetHinderenceForPlayer2()
        {
            Player2Camera.GetComponent<CameraFilterPack_TV_Vcr>().enabled = true;
            Player2Camera.GetComponent<CameraFilterPack_TV_VHS>().enabled = true;
            yield return new WaitForSeconds(10.0f);
            Player2Camera.GetComponent<CameraFilterPack_TV_Vcr>().enabled = false;
            Player2Camera.GetComponent<CameraFilterPack_TV_VHS>().enabled = false;
        }
    }
}
