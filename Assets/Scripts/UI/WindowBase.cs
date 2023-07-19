using UnityEngine;

namespace UI
{
    public class WindowBase : MonoBehaviour, IWindow
    {
        [SerializeField] private string windowName;
        
        public string GetWindowName()
        {
            return windowName;
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}