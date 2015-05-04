using UnityEngine;

namespace HeroesOfDice.Util
{
    public class RandomRotation : MonoBehaviour
    {
        public void OnEnable()
        {
            transform.rotation = Quaternion.Euler(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f));
            GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f)) * 200f);
            enabled = false;
        }
    }
}
