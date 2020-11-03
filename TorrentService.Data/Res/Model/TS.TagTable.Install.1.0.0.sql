--[beginscript]
create table TS.tTag (
    TagId int not null,
    TagName nvarchar(255) unique not null,
    constraint PK_TS_tTag primary key clustered( TagId ),
    constraint FK_TS_tTag_GroupId foreign key ( TagId ) references CK.tGroup( GroupId )
);
--[endscript]
