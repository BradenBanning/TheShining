using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public static class PoolManager
    {
        private static readonly int _DEFAULT_POOL_SIZE = 10;
        private static Dictionary<int, List<PoolableObject>> _Pools = new Dictionary<int, List<PoolableObject>>();
        private static Dictionary<int, int> _Indexes = new Dictionary<int, int>();

        private static PoolableObject AddObjectToPool(PoolableObject prefab, int poolId)
        {
            var clone = GameObject.Instantiate(prefab);
            clone.gameObject.SetActive(false);
            _Pools[poolId].Add(clone);
            return clone;
        }

        public static void CreatePool(PoolableObject prefab, int poolSize)
        {
            var poolId = prefab.GetInstanceID();
            _Pools[poolId] = new List<PoolableObject>(poolSize);
            _Indexes[poolId] = -1;
            for (int i = 0; i < poolSize; i++)
            {
                AddObjectToPool(prefab, poolId);
            }
        }

        public static PoolableObject GetNext(PoolableObject prefab, Vector3 pos, Quaternion rot, bool active = true)
        {
            var clone = GetNext(prefab);
            clone.transform.position = pos; 
            clone.transform.rotation = rot;
            clone.gameObject.SetActive(active);
            return clone;
        }

        public static PoolableObject GetNext(PoolableObject prefab)
        {
            var poolId = prefab.GetInstanceID();
            if(_Pools.ContainsKey(poolId) == false)
            {
                CreatePool(prefab, _DEFAULT_POOL_SIZE);
            }

            var currentPoolableObjectsList = _Pools[poolId];

            for (int i = 0; i < currentPoolableObjectsList.Count; i++)
            {
                _Indexes[poolId] = (_Indexes[poolId] + 1) % _Pools[poolId].Count;
                var checkIndex = _Indexes[poolId];
                if(currentPoolableObjectsList[checkIndex].gameObject.activeInHierarchy == false)
                {
                    return currentPoolableObjectsList[checkIndex];
                }
            }

            return AddObjectToPool(prefab, poolId);
        }
    }
}