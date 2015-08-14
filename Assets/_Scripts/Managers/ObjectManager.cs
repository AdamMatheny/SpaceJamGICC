using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Assets._Scripts.Audio;

namespace Assets._Scripts.Managers
{
	public class ObjectManager : Singleton<ObjectManager>
	{
		public Transform ContainerTransform;
		public Transform EnemyTransform;
	}
}
