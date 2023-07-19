using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace CustomDI
{
    public abstract class InstallerBase : MonoBehaviour, IActivatable
    {
        [SerializeField]
        StandartActivator activator = new StandartActivator(ActivationMode.start);

        private void Awake()
        {
            activator.TryActivateOnAwake(InjectDependencies);
        }
        private void Start()
        {
            activator.TryActivateOnStart(InjectDependencies);
        }        
        private void OnEnable()
        {
            activator.TryActivateOnEnable(InjectDependencies);
        }
        public void Activate()
        {
            activator.TryActivateExternal();
        }
        protected void InjectDependencies()
        {
            var behaiviours = GetComponents<MonoBehaviour>().Where(x => x != this);
            foreach (var x in behaiviours)
            {
                var injectMethods = x.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Where(x => x.GetCustomAttributes<InjectableAttribute>(false).Any());
                foreach (var injectMethod in injectMethods)
                {
                    var parametres = injectMethod.GetParameters();

                    object[] args = new object[parametres.Length];
                    for (int i = 0; i < parametres.Length; i++)
                    {
                        Type parameterType = parametres[i].ParameterType;
                        args[i] = GetInjectArg(parameterType);
                    }

                    injectMethod.Invoke(x, args);
                }
            }
        }

        protected abstract object GetInjectArg(Type parameterType);
    }
}