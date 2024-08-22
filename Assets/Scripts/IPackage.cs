using UnityEngine;

public interface IPackage : IRemovable
{
    Color32 PackageColor { get; }
    int TimeLimit { get; }
    bool IsFragile { get; }
    ICustomer Recipient { get; }
        
}
