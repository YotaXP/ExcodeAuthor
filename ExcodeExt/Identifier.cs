using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcodeAuthor
{
    public class Identifier
    {
        public string Name;
        //public IdentifierType Type;
        public List<IdentifierUsage> Usage = new List<IdentifierUsage>();
    }

    public struct IdentifierUsage
    {
        public bool Read;
        public bool Write;
        public int Line;
        public int Param;
    }

    //public enum IdentifierType
    //{
    //    Variable,
    //    Label
    //}
}
