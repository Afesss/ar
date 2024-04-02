using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Code
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Material _templMaterial;
        [SerializeField] private PortalTrigger _portalTrigger;
        
        private static readonly int StencilComp = Shader.PropertyToID("_StencilComp");
        private bool _templeFullRender;
        private void Start()
        {
            _portalTrigger.Triggered += InsidePortalTriggerOnTriggered;
            _templeFullRender = false;
        }

        private void OnDestroy()
        {
            _portalTrigger.Triggered -= InsidePortalTriggerOnTriggered;
            _templMaterial.SetInt(StencilComp, (int)CompareFunction.Equal);
        }
        
        private void InsidePortalTriggerOnTriggered()
        {
            SetTempleMaterial();
        }

        private void SetTempleMaterial()
        {
            _templeFullRender = !_templeFullRender;
            var stencilTest = _templeFullRender ? CompareFunction.NotEqual : CompareFunction.Equal;

            _templMaterial.SetInt(StencilComp, (int)stencilTest);
        }
    }
}
