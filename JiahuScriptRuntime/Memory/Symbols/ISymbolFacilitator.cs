using System;

namespace JiahuScriptRuntime.Memory.Symbols
{
    public interface ISymbolFacilitator
    {
        Symbol Create(string identifier, string type);
        Type ConvertValueType(string typeName);
        bool AllowedTypeAssignment(Symbol assignedType, Symbol assigningType);
        string GetBaseType(string valueType);
        bool IsValueTypeValid(string type, object value, bool throwException = true);
        void SetSymbolValue(Symbol symbol, object value);
        void SetSymbolValue(Symbol symbol, Symbol value);
        string GetValueAsString(Symbol symbol);
        string GetValueAsString(Symbol symbol, int index);
        object GetValueAsObject(Symbol symbol);
        object GetValueAsObject(Symbol symbol, int index);
        Array ConvertToArray(object values, string type);
        string ConvertTypeName(Type type);
        Type ConvertSymbolToType(Symbol symbol);
    }
}