using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcodeAuthor
{
    public struct Error
    {
        public int Line;
        public ErrorType Type;
        public string Message;
    }

    public enum ErrorType
    {
        DuplicateLabel,
        NonExistingLabel,
        VariableNeverAssigned,
        VariableNeverRead,
        VariableBeginsWithDigit,
        BadCommand,
        ExpectedVariable,
        BadParameterCount,
        BadParameter,
        BadOperator,
        BlankLine,
        LeadingWhitespace,
        Comment
    }
}
