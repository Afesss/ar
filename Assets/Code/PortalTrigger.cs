using System;
using UnityEngine;

namespace Code
{
    public class PortalTrigger : MonoBehaviour
    {
        public event Action Triggered; 
        private void OnTriggerEnter(Collider other)
        {
            Triggered?.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            
        }
    }
}
