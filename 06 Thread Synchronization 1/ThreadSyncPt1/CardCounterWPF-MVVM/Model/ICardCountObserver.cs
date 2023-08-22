namespace CardCounterWPF_MVVM.Model
{
    public interface ICardCountObserver
    {
        void Update(CardCountSubject.UpdatedField field);
    }
}