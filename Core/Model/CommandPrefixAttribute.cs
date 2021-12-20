namespace ThesareaClient.Core.Model;

[Serializable]
[AttributeUsage(AttributeTargets.Method)]
internal class CommandPrefixAttribute : Attribute
{
    internal CommandPrefixAttribute(params string[] prefixs) { Prefixs = prefixs; }

    internal string[] Prefixs { get; }
}
