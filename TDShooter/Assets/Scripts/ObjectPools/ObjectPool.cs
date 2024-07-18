using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TopDownShooter
{
    public class ObjectPool
    {
        private DiContainer _container;
        private GameObject _prefab;
        private List<GameObject> _stack;

        public ObjectPool(GameObject prefab, int initialSize)
        {
            _prefab = prefab;
            _stack = new List<GameObject>();
            for (int i = 0; i < initialSize; i++) 
            {
                GameObject obj = Create();
                _stack.Add(obj);
            }
        }

        public GameObject Get(bool needActivate = true)
        {
            GameObject obj = _stack.FirstOrDefault(x => !x.activeSelf);

            if (obj == null)
                obj = Create();
            if (needActivate) 
                obj.SetActive(true);
            return obj;
        }

        private GameObject Create()
        {
            GameObject obj = GameObject.Instantiate(_prefab);
            obj.SetActive(false);
            _stack.Add(obj);
            return obj;
        }
    }
}