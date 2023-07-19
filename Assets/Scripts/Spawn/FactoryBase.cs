using UnityEngine;

namespace Spawn
{
    public abstract class FactoryBase : ScriptableObject
    {
        protected T CreateInstance<T>(T prefabToCreate, Vector3 position) where T : MonoBehaviour
        {
            return Instantiate(prefabToCreate, position, Quaternion.identity); //In the future can be done through the pool
        }   
    }
}