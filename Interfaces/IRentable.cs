namespace InheritanceProject
{
    public interface IRentable: IInventoryItem
    {
        void Rent();
        void ReturnRental();
    }
}

