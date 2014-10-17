namespace HungryPesho.Items
{
    interface ICollectible
    {
        string Name { get; set; }

        ItemTypes ItemType { get; set; }
    }
}