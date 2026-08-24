using System;
using System.Collections.Generic;
using System.Text;

namespace Opgave02.model
{
        public record PotterCharacter(
                string FullName,
                string NickName,
                string HogwartsHouse,
                string InterpretedBy,
                List<string> Children,
                string Image, 
                string BirthDate, 
                int Index);
        
}
