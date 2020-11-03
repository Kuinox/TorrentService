using CK.Core;

namespace TorrentService.Data
{
    [SqlPackage(
        ResourcePath = "Res",
        Schema = "TS",
        Database = typeof( SqlDefaultDatabase ),
        ResourceType = typeof( Package ) ),
        Versions( "1.0.0" )]
    public abstract class Package : SqlPackage
    {
        void StObjConstruct( CK.DB.User.UserPassword.Package userPwd )
        {

        }
    }
}
