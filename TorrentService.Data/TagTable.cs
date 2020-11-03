using CK.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorrentService.Data
{
    [SqlTable( "tTag", Schema = "TS", Package = typeof( Package ) ), Versions( "1.0.0" )]
    public abstract class TagTable : SqlTable
    {
    }
}
