using System;
using System.ComponentModel;

namespace obligatorisk_opgave_beer
{
    public class Beer
    {
        private int ID_;
        private string Name_;
        private int Price_;
        private int ABV_;

        public Beer (int ID, string Name, int Price, int ABV)
        {
            ID_ = ID;
            Name_ = Name;
            Price_ = Price;
            ABV_ = ABV;
        }

        public int ID
        {
            get => ID_;
            set
            {
                if (value <= 0) { throw new ArgumentException(); }
                ID_ = value;
            }
        }
        
        public string Name 
        { 
            get => Name_;
            set 
            {
                if (value.Length < 4) { throw new ArgumentException(); }
                Name_ = value;
            }
        }

        public int Price 
        {
            get => Price_;
            set
            {
                if (value <= 0) { throw new ArgumentException(); }
                Price_ = value;
            }
                
        }

        public int ABV 
        { 
            get => ABV_; 
            set
            {
                if (value < 0 || value > 100) { throw new ArgumentOutOfRangeException(); }
                ABV_ = value;
            }
        }
        public Beer()
        {

        }
        public override string ToString()
        {
            return Name + " " + ID + " " + Price + " " + ABV;
        }
    }
}
