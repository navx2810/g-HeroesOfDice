using UnityEngine;

namespace HeroesOfDice.Util
{
   public class RandomRotation : MonoBehaviour
    {
        void Start()
        {
            float x = Random.Range(0, 360f);
            float y = Random.Range(0, 360f);
            float z = Random.Range(0, 360f);

            transform.rotation = new Quaternion(x, y, z, 1f);
        }
    }
}
