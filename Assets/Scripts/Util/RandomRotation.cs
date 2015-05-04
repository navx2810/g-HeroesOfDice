using UnityEngine;

namespace HeroesOfDice.Util
{
    public class RandomRotation : MonoBehaviour
    {

        public Vector3 ForwardVector;

        public void OnEnable()
        {
            var rb = GetComponent<Rigidbody>();
            transform.rotation = Quaternion.Euler(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f));
            rb.AddTorque(new Vector3(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f)) * 200f);
            rb.AddForce(ForwardVector * 100);
            enabled = false;
        }
    }
}
