

using B_B_ClassLibrary.BusinessModels;

namespace B_B_App
{
    public class NewBookingsContainer
    {
        public List<Contract>? newBookings { get; set; } = new List<Contract>();

        public void AddContract(Contract contract)
        {
            newBookings.Add(contract);
            NotifyStateChanged();
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
