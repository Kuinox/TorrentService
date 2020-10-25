using CK.Core;

namespace Automelec.Data
{
    [SqlPackage(
        ResourcePath = "Res",
        Schema = "TS",
        Database = typeof( SqlDefaultDatabase ),
        ResourceType = typeof( Package ) ),
        Versions( "1.0.0" )]
    public abstract class Package : SqlPackage
    {
    }
}
