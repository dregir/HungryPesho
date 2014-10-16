namespace HungryPesho.Creatures
{
    using HungryPesho.Creatures;

    interface IPlayer
    {
        int PlayerLevel { get; set; }

        Character PlayerCharacter { get; set; }
    }
}