using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class WindowSwitcherCore : MonoBehaviour, IWindowSwitcher
    {
        [SerializeField] 
        private string startWindowName = "Game";
        
        private IWindow _currentWindow;
        private IWindow[] _windows;
        private void Start()
        {
            GetAllWindows();
            DeactivateAllWindow();
            TryOpenWindow(startWindowName);
        }
        public bool TryOpenWindow(string windowName)
        {
            IWindow targetWindow = GetWindowByName(windowName);
            
            if(_currentWindow != null) _currentWindow.Close();

            _currentWindow = targetWindow;
            _currentWindow.Open();
            
            return true;
        }
        
        private IWindow GetWindowByName(string targetName)
        {
            IWindow targetWindow = null;

            foreach (var window in _windows)
            {
                if (window.GetWindowName() == targetName)
                {
                    targetWindow = window;
                }
            }

            return targetWindow;
        }

        private void GetAllWindows()
        {
            List<IWindow> windows = new List<IWindow>();
            windows.AddRange(transform.GetComponentsInChildren<IWindow>());
            _windows = windows.ToArray();
        }

        private void DeactivateAllWindow()
        {
            foreach (var window in _windows)
            {
                window.Close();
            }
        }
    }
}