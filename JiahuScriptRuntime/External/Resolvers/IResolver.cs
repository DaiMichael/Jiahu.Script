namespace JiahuScriptRuntime.External.Resolvers
{
    public interface IResolver
    {
        object Resolve(object item, string resolveName, object[] parameters = null);
    }
}
