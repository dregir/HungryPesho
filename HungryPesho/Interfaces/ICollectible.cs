namespace HungryPesho.Items
{
    interface ICollectible
    {
        int ItemId { get; set; }

        string ItemName { get; set; }

        string ItemDescription { get; set; }
    }
}