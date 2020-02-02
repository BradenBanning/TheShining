using System.Collections;
using UnityEngine;

namespace ObjectPooling
{
    public class PoolableObject : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("If Lifespan < 0, then it will not auto disable")]
        private float _Lifespan = 3f;

        private void OnEnable()
        {
            if (_Lifespan >= 0f)
            {
                StartCoroutine(Disabler());
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator Disabler()
        {
            yield return new WaitForSeconds(_Lifespan);
            gameObject.SetActive(false);
        }

        public void StartDisabler()
        {
            StartCoroutine(Disabler());
        }
    }
}