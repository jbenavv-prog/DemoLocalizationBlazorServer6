namespace DemoLocalizationBlazorServer6.Services
{
    public class CultureChangedEventService
    {
        public event Action OnCultureChanged;
        public void NotifyCultureChanged() => OnCultureChanged?.Invoke();
    }
}
