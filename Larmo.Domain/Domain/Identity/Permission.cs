namespace Larmo.Domain.Domain.Identity;

public class Permission
{
    private Permission()
    {
    }

    public string Id { get; private set; }
    public string Name { get; private set; }
    public string DependOn { get; private set; }
    public string ModuleName { get; private set; }
    public Permission Parent { get; private set; }

    public static Permission Create(string id, string name, string moduleName, string dependOn)
    {
        var permission = new Permission
        {
            Id = id,
            Name = name,
            ModuleName = moduleName,
            DependOn = dependOn
        };

        return permission;
    }
}