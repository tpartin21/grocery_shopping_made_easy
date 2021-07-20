using System;
using System.Collections.Generic;
using System.Text;

namespace grocery_shopping_made_easy
{
    internal class ExpirationDate
    {
        Console.WriteExpirationDateNewStruct("Enter expiration date (e.g. 10/22/1987): ");
        DateTime inputtedDate = DateTime.Parse(Console.ReadLine());
    }
}
