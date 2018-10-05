using System;
using System.Collections.Generic;
using System.Text;

namespace myTodo.viewModell
{
    public class taskViewModell
    {
        public static readonly string[] PriorityTexts={"Ráér","Normál","Sügrős"};
        public String Title { get; set; }
        public int Priority { get; set; } = 1;
        public string PriorityText {
            get {
                return PriorityTexts[Priority];
                    }
        } 
        public DateTime Due { get; set; }
        public bool isSolved { get; set; }

    }
}
