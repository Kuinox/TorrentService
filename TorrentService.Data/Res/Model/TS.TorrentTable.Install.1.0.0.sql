--[beginscript]
create table TS.tTorrent (
	TorrentId int identity(1,1) primary key not null,
    AclId int not null foreign key references CK.tAcl(AclId),
    FileId int not null foreign key references TS.tFile(FileId)
);
--[endscript]
