using System;

namespace DefaultNamespace
{
    public class EndGameWindow : Window
    {
        public event Action RestartButtonClicked;
        
        protected override void OnButtonClick()
        {
            RestartButtonClicked?.Invoke();
        }

        public override void Open()
        {
            WindowGroup.alpha = 1f;
            ActionButton.interactable = true;
        }

        public override void Close()
        {
            WindowGroup.alpha = 0f;
            ActionButton.interactable = false;
        }
    }
}