--[beginscript]
create table TS.tFileTable (
	FileId int identity(1,1) primary key not null,
	FileHash binary(32) unique not null,
	URI nvarchar(max) unique not null
);
--[endscript]
