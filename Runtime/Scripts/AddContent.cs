using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GURHelper
{
    /// <summary>
    /// Script para a�adir al Scroll View el contenido del panel, seg�n la prueba que sea.
    /// </summary>
    public class AddContent : MonoBehaviour
    {
        private ScrollRect scrollRect;
        private RectTransform viewport;
        private Test pruebaPrefab;
        private GameObject testInstance;

        /// <summary>
        /// Usamos Awake para poder catchear los componentes antes de que se llame a OnEnable
        /// </summary>
        void Awake()
        {
            scrollRect = GetComponent<ScrollRect>();
            viewport = scrollRect.viewport;
        }
        /// <summary>
        /// Usamos OnEnable y OnDisable porque el Canvas aparecer� y desaparecer� cuando sea necesario.
        /// </summary>
        private void OnEnable()
        {
            //instanciamos la prueba correspondiente
            testInstance = Instantiate<GameObject>(pruebaPrefab.gameObject, viewport.gameObject.transform);
            scrollRect.content = testInstance.GetComponent<RectTransform>();
            testInstance.GetComponent<Pagination>().scrollRect = scrollRect;
        }
        public void SetTest(Test test)
        {
            pruebaPrefab = test;
        }
        private void OnDisable()
        {
            Destroy(testInstance);
        }
    }
}