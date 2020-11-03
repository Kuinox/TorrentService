using CK.Core;
using CK.SqlServer;
using System.Threading.Tasks;

namespace TorrentService.Data
{
    [SqlTable("tFileTable", Schema = "TS", Package = typeof( Package ) ), Versions("1.0.0")]
    public abstract class FileTable : SqlTable
    {

    }
}
