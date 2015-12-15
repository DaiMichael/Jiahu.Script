namespace JiahuScriptRuntime.External.Reflectors
{
    internal interface IReflector
    {
        object Reflect(object item, string callName, object[] parameters = null);
    }
}