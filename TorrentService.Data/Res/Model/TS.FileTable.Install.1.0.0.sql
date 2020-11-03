--[beginscript]
create table TS.tFile (
	FileId int identity(1,1) primary key not null,
	FileHash binary(32) unique not null,
	URI nvarchar(2000) unique not null
);
--[endscript]
