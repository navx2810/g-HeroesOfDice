using System;
using UnityEngine;

namespace HeroesOfDice
{
    [Serializable]
    public abstract class BMenuState : MonoBehaviour
    {
        public abstract void OnEnter();
        public abstract void OnLeave();
    }
}
