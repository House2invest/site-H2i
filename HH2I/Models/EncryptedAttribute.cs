namespace House2Invest.Models
{
    using System;

    [AttributeUsage((AttributeTargets) AttributeTargets.Property, Inherited=false, AllowMultiple=false)]
    internal sealed class EncryptedAttribute : Attribute
    {
        private readonly string _fieldName;

        public EncryptedAttribute(string fieldName)
        {
            this._fieldName = fieldName;
        }

        public string FieldName
        {
            get
            {
                return this._fieldName;
            }
        }
    }
}

