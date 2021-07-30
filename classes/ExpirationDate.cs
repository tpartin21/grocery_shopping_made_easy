using System;
using System.Collections.Generic;
using System.Text;

namespace grocery_shopping_made_easy
{
    internal class ExpirationDate
    {
        public object Milk;
        public object Pasta;

        public ExpirationDate(object Milk, object Pasta)
        {
            this.Milk = Milk;
            this.Pasta = Pasta;
        }

        public override bool Equals(object obj)
        {
            return obj is ExpirationDate other &&
                EqualityComparer<object>.Default.Equals(Milk, other.Milk) &&
                EqualityComparer<object>.Default.Equals(Pasta, other.Pasta);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Milk, Pasta);
        }

        public void Deconstruct(out object Milk, out object Pasta)
        {
            Milk = this.Milk;
            Pasta = this.Pasta;
        }

        public static implicit operator (object, object)(ExpirationDate value)
        {
            return (value.Milk, value.Pasta);
        }
    }
}
  
        
    
   
      


