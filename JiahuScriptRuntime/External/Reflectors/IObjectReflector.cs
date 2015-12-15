namespace JiahuScriptRuntime.External.Reflectors
{
    internal interface IObjectReflector
    {
        object Reflect(object item, string callName, object[] parameters = null, bool isFunctionCall = false);
    }
}