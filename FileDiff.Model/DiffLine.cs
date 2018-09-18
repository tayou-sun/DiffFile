using System;

namespace FileDiff.Model
{
    public class DiffLine
    {
        public DiffType DiffType { get; set; }

        public string Value { get; set; }

        public DiffLine(DiffType diffType, string value)
        {
            DiffType = diffType;
            Value = value;
        }
    }
}
