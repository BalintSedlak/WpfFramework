using System;
using System.Windows.Controls;

namespace WpfFramework
{
    public class NavigationService : ViewModelBase
    {
        private Frame _frame;
        private Page _currentContent;

        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand GoForwardCommand { get; set; }

        public Page CurrentContent
        {
            get { return _currentContent; }
            set { SetField(ref _currentContent, value, nameof(CurrentContent)); }
        }

        public NavigationService()
        {
            GoBackCommand = new RelayCommand(GoBack, CanGoBack);
            GoForwardCommand = new RelayCommand(GoForward, CanGoForward);
        }

        public void SetFrame(Frame frame)
        {
            if (frame is null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            _frame = frame;
        }

        public void NavigateTo(Page page)
        {
            if (page is null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            CurrentContent = page;
        }

        public bool IsActiveContent(Page page)
        {
            if (!Page.Equals(_currentContent, page))
            {
                return false;
            }

            return true;
        }

        public bool CanGoBack()
        {
            if (!_frame.CanGoBack)
            {
                return false;
            }

            return true;
        }

        public bool CanGoForward()
        {
            if (!_frame.CanGoForward)
            {
                return false;
            }

            return true;
        }

        public void GoBack()
        {
            if (!_frame.CanGoBack)
            {
                return;
            }

            _frame.GoBack();
        }

        public void GoForward()
        {
            if (!_frame.CanGoForward)
            {
                return;
            }

            _frame.GoForward();
        }
    }
}
