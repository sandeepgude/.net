using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RevString
{
    public class StringReversor : IStringReversor
    {
        readonly IRepository repository;

        public StringReversor(IRepository repository)
        {
            this.repository = repository;
        }


        /// <summary>
        /// This Method takens an input from the database(MOQ),
        /// reverse the positions of all alpha-numeric characters having those characters 
        /// not reversed maintain their original position and
        /// returns reversed string
        /// </summary>

        public string Reverse_String()
        {
            var str = repository.GetString();
            char[] charArray = str.ToCharArray();
            StringBuilder ans = new StringBuilder();
            int j = charArray.Length - 1;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (Char.IsLetter(charArray[i]) || Char.IsNumber(charArray[i]))
                {
                    while (!Char.IsLetter(charArray[j]) && !(Char.IsNumber(charArray[j])))
                        j--;
                    ans.Append(charArray[j--]);
                }
                else
                {
                    ans.Append(charArray[i]);
                }

            }
            return ans.ToString();
        }
    }
}