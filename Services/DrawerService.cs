using System.Threading;

namespace UseallConecta.Services;

    public class DrawerService
    {
        private readonly SynchronizationContext _syncContext;

        public DrawerService()
        {
            _syncContext = SynchronizationContext.Current!;
        }

        public event Action? OnChange;

        private bool _isOpen = false;

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                if (_isOpen != value)
                {
                    _isOpen = value;
                    NotifyStateChanged();
                }
            }
        }

        public void Toggle()
        {
            IsOpen = !IsOpen;
        }

        public void Open()
        {
            IsOpen = true;
        }

        public void Close()
        {
            IsOpen = false;
        }

        private void NotifyStateChanged()
        {
            _syncContext.Post(_ => OnChange?.Invoke(), null);
        }
    }

