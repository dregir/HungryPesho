namespace HungryPesho.Items
{
    using System.Collections;

    public enum EquipmentTypes
    {
        HEAD,
        CHEST,
        SHOLDERS,
        LEGS,
        FEET,
        RINGS
    }

    public abstract class Equipment //: StatItem
    {
        private EquipmentTypes equipmentType;



        public EquipmentTypes EquipmentType
        {
            get
            {
                return equipmentType;
            }

            set
            {
                equipmentType = value;
            }
        }
    }
}