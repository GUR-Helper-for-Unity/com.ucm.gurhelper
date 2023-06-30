using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GURHelper
{
    public class MouseScrollBar : MonoBehaviour
    {
        private float mouseScrollValue = 0;
        public float sensibility = 0.1f;
        private Scrollbar _scrollbarComponent = null;

        // Start is called before the first frame update
        void Start()
        {
            _scrollbarComponent = GetComponent<Scrollbar>();
        }

        // Update is called once per frame
        void Update()
        {
            mouseScrollValue = Input.mouseScrollDelta.y * sensibility;
            if (_scrollbarComponent != null) _scrollbarComponent.value += mouseScrollValue;

            _scrollbarComponent.value = Mathf.Clamp01(_scrollbarComponent.value);

        }
    }
}