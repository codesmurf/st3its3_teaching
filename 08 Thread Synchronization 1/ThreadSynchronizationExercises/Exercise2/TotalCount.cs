namespace Exercise2
{
    class TotalCount
    {
        private readonly object _toLockOn = new object();

        public int Count { get; private set; } = 0;

        public void Increment()
        {
            lock (_toLockOn)
            {
                Count = Count + 1;
            }
        }
    }
}
