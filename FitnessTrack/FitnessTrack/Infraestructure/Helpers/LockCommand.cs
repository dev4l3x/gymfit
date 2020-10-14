using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessTrack.Infraestructure.Helpers
{
    public class LockCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;
        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                if(_isExecuting != value)
                {
                    _isExecuting = value;
                    CanExecuteChanged.Invoke(this, new EventArgs());
                }
            }
        }

        private bool _hasParameter;

        private Func<Task> _callbackWithoutParameter;
        private Func<object, Task> _callbackWithParameter;

        private bool _onlyExecuteOnce;

        public LockCommand(Func<Task> callback, bool onlyExecuteFirstTime = false)
        {
            Initialize(onlyExecuteFirstTime);
            _hasParameter = false;
            _callbackWithoutParameter = callback;
        }

        public LockCommand(Func<object, Task> callback, bool onlyExecuteFirstTime = false)
        {
            Initialize(onlyExecuteFirstTime);
            _hasParameter = true;
            _callbackWithParameter = callback;
        }

        private void Initialize(bool onlyFirstTime)
        {
            _onlyExecuteOnce = onlyFirstTime;
        }

        public bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public async void Execute(object parameter)
        {
            if(CanExecute(null))
            {
                IsExecuting = true;
                if (_hasParameter)
                    await _callbackWithParameter(parameter);
                else
                    await _callbackWithoutParameter();

                if (!_onlyExecuteOnce)
                    IsExecuting = false;
            }
        }
    }
}
